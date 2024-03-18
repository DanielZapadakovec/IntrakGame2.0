using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;

    private bool isDragging = false;
    private Vector2 startPosition;
    public static GameObject dropZone;
    private bool isDraggable = true;
    private bool isOverDropZone = false;
    private GameObject startParent;
    public Vector2 deckposition;
    public DrawCards drawCards;
    public GameManager gameManager;
    public bool areinViewArea;
    public GameObject DropZone;
    public Text logtext;
    public GameObject WaitPanel;
    public int a = 10;


    void Start()
    {
        WaitPanel = GameObject.Find("WaitPanel").GetComponent<GameObject>();
        Canvas = GameObject.Find("MainCanvas");
        drawCards = GameObject.Find("DrawCardButton").GetComponent<DrawCards>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        DropZone = GameObject.Find("DropZone");

    }
    void Update()
    {


        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }



    public void StartDrag()
    {
        if (areinViewArea == false)
        {


            if (!isDraggable) return;
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
            isDragging = true;
        }

    }
    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropZone == true)
        {

            dropZone.GetComponent<DropZone>().AddToDiscardPile(gameObject);

            if (DrawCards.drawablecardforPlayer)
            {
                DrawCards.cardsPlayerDeck.Remove(gameObject);
            }
            else if (DrawCards.drawablecardforEnemy)
            {
                DrawCards.cardsEnemyDeck.Remove(gameObject);

            }

            transform.SetParent(dropZone.transform, true);
            isDraggable = false;
            TestingCard();
        }
        else
        {
            transform.position = startPosition;
            transform.localScale = Vector3.one;
            transform.SetParent(startParent.transform, false);
        }
    }

    public void TestingCard()
    {
        int cardId = GetComponent<CardIdentity>().ID;
         if (cardId == 2 && DrawCards.drawablecardforPlayer)
        {
            DropZone.SetActive(false);
            gameManager.buttonToGetBackCards.SetActive(true);
            areinViewArea = true;
            drawCards.CanBeDrawed = false;
            Debug.Log("Hráè si pozrie prvé tri karty z balíèka.");
            for (int i = 0; i < 3 && i < drawCards.cardsInDeck.Count; i++)
            {
                gameManager.topThree.Add(drawCards.cardsInDeck[drawCards.cardsInDeck.Count - 1 - i]);
            }
            for (int i = 0; i < 3 && i < drawCards.cardsInDeck.Count; i++)
            {
                GameObject card = Instantiate(drawCards.cardsInDeck[drawCards.cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
                card.transform.SetParent(drawCards.ViewPlayerArea.transform, false);
                drawCards.cardsInDeck.RemoveAt(drawCards.cardsInDeck.Count - 1);
            }
            Debug.Log("boli vzate");

        }
        else if (cardId == 2 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Enemy si pozrie prvé tri karty z balíèka.");
            DropZone.SetActive(false);
            gameManager.buttonToGetBackCards.SetActive(true);
            areinViewArea = true;
            drawCards.CanBeDrawed = false;
            for (int i = 0; i < 3 && i < drawCards.cardsInDeck.Count; i++)
            {
                gameManager.topThree.Add(drawCards.cardsInDeck[drawCards.cardsInDeck.Count - 1 - i]);
            }
            for (int i = 0; i < 3 && i < drawCards.cardsInDeck.Count; i++)
            {
                GameObject card = Instantiate(drawCards.cardsInDeck[drawCards.cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
                card.transform.SetParent(drawCards.ViewPlayerArea.transform, false);
                drawCards.cardsInDeck.RemoveAt(drawCards.cardsInDeck.Count - 1);
            }
            Debug.Log("boli vzate");
        }
        else if (cardId == 3 && DrawCards.drawablecardforPlayer)
        {
            DrawCards.drawablecardforEnemy = true;
            DrawCards.drawablecardforPlayer = false;
            GameObject card = Instantiate(drawCards.cardsInDeck[drawCards.cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(drawCards.EnemyArea.transform, false);

            WaitPanel.SetActive(true);

            DrawCards.cardsEnemyDeck.Add(card);
            drawCards.cardsInDeck.RemoveAt(drawCards.cardsInDeck.Count - 1);
            Debug.Log("Karta s ID 3 je v dropzóne. Enemy si berie 2 karty ");

        }
        else if (cardId == 3 && DrawCards.drawablecardforEnemy)
        {
            DrawCards.drawablecardforEnemy = false;
            DrawCards.drawablecardforPlayer = true;
            GameObject card = Instantiate(drawCards.cardsInDeck[drawCards.cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(drawCards.PlayerArea.transform, false);

            WaitPanel.SetActive(true);

            DrawCards.cardsPlayerDeck.Add(card);
            drawCards.cardsInDeck.RemoveAt(drawCards.cardsInDeck.Count - 1);
            Debug.Log("Karta s ID 3 je v dropzóne. Enemy si berie 2 karty ");
            Debug.Log("Karta s ID 3 je v dropzóne. Player si berie 2 karty ");
        }
        else if (cardId == 4 && DrawCards.drawablecardforPlayer)
        {
            TakeRandomCardFromEnemy();
        }
        else if (cardId == 4 && DrawCards.drawablecardforEnemy)
        {
            TakeRandomCardFromPlayer();
        }
        else if (cardId == 5 && DrawCards.drawablecardforPlayer)
        {
            Debug.Log("Karty boli zamiešane");
            drawCards.ShuffleCardsInDeck();
        }
        else if (cardId == 5 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Karty boli zamiešane");
            drawCards.ShuffleCardsInDeck();
        }
        else if (cardId == 6 && DrawCards.drawablecardforPlayer)
        {
            WaitPanel.SetActive(true);
            DrawCards.drawablecardforEnemy = true;
            DrawCards.drawablecardforPlayer = false;
        }
        else if (cardId == 6 && DrawCards.drawablecardforEnemy)
        {
            WaitPanel.SetActive(false);
            DrawCards.drawablecardforPlayer = true;
            DrawCards.drawablecardforEnemy = false;
        }
        else if (cardId == 7 && DrawCards.drawablecardforPlayer)
        {
            if (DrawCards.LastDroppedCardByPlayer)
            {

                TakeRandomCardFromEnemy();
            }
            DrawCards.LastDroppedCardByPlayer = true;
            Debug.Log("prvarandomkarta1tamjeFromPlayer");
            
        }
        else if (cardId == 7 && DrawCards.drawablecardforEnemy)
        {
            if (DrawCards.LastDroppedCardByEnemy)
            {
                TakeRandomCardFromPlayer();
            }
            DrawCards.LastDroppedCardByEnemy = true;
            Debug.Log("prvarandomkarta1tamjeFromEnemy");
        }
        else if (cardId == 8 && DrawCards.drawablecardforPlayer)
        {
            if (DrawCards.LastDroppedCardByPlayer8)
            {

                TakeRandomCardFromEnemy();
            }
            DrawCards.LastDroppedCardByPlayer8 = true;
            Debug.Log("prvarandomkarta2tamjeFromPlayer");

        }
        else if (cardId == 8 && DrawCards.drawablecardforEnemy)
        {
            if (DrawCards.LastDroppedCardByEnemy8)
            {
                TakeRandomCardFromPlayer();
            }
            DrawCards.LastDroppedCardByEnemy8 = true;
            Debug.Log("prvarandomkarta2tamjeFromEnemy");
        }
        else if (cardId == 9 && DrawCards.drawablecardforPlayer)
        {
            if (DrawCards.LastDroppedCardByPlayer9)
            {

                TakeRandomCardFromEnemy();
            }
            DrawCards.LastDroppedCardByPlayer9 = true;
            Debug.Log("prvarandomkarta3tamjeFromPlayer");

        }
        else if (cardId == 9 && DrawCards.drawablecardforEnemy)
        {
            if (DrawCards.LastDroppedCardByEnemy9)
            {
                TakeRandomCardFromPlayer();
            }
            DrawCards.LastDroppedCardByEnemy9 = true;
            Debug.Log("prvarandomkarta3tamjeFromEnemy");
        }

    }


    private void TakeRandomCardFromEnemy()
    {
        if (DrawCards.cardsEnemyDeck.Count > 0)
        {
            int randomIndex = Random.Range(0, DrawCards.cardsEnemyDeck.Count);
            GameObject randomCard = DrawCards.cardsEnemyDeck[randomIndex];
            GameObject newCardObject = Instantiate(randomCard, drawCards.PlayerArea.transform.position, Quaternion.identity);
            newCardObject.transform.SetParent(drawCards.PlayerArea.transform, false);

            DrawCards.cardsEnemyDeck.Remove(randomCard);

            DrawCards.cardsPlayerDeck.Add(newCardObject);

            Destroy(randomCard);
            DrawCards.LastDroppedCardByPlayer = false;
            DrawCards.LastDroppedCardByPlayer8 = false;
            DrawCards.LastDroppedCardByPlayer9 = false;
        }
    }

    private void TakeRandomCardFromPlayer()
    {
        if (DrawCards.cardsPlayerDeck.Count > 0)
        {
            int randomIndex = Random.Range(0, DrawCards.cardsPlayerDeck.Count);
            GameObject randomCard = DrawCards.cardsPlayerDeck[randomIndex];
            GameObject newCardObject = Instantiate(randomCard, drawCards.EnemyArea.transform.position, Quaternion.identity);
            newCardObject.transform.SetParent(drawCards.EnemyArea.transform, false);

            DrawCards.cardsPlayerDeck.Remove(randomCard);

            DrawCards.cardsEnemyDeck.Add(newCardObject);

            Destroy(randomCard);
            DrawCards.LastDroppedCardByEnemy = false;
            DrawCards.LastDroppedCardByEnemy8 = false;
            DrawCards.LastDroppedCardByEnemy9 = false;

        }
    }


}

