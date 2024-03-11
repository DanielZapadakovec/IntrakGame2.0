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


    private int lastDroppedCardId = -1;
    private bool lastDroppedCardByPlayer = false;
    private bool lastDroppedCardByEnemy = false;


    void Start()
    {
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
        if (cardId == 0 && DrawCards.drawablecardforPlayer)
        {
            Debug.Log("Karta s ID 0 je v dropzóne. Vykonávam špecifickú akciu.");
        }
        else if (cardId == 0 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Karta s ID 0 je v dropzóne. Vykonávam špecifickú akciu.");
        }
        else if (cardId == 2 && DrawCards.drawablecardforPlayer)
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

            DrawCards.cardsPlayerDeck.Add(card);

            drawCards.cardsInDeck.RemoveAt(drawCards.cardsInDeck.Count - 1);
            Debug.Log("Karta s ID 3 je v dropzóne. Enemy si berie 2 karty ");
            Debug.Log("Karta s ID 3 je v dropzóne. Player si berie 2 karty ");
        }
        else if (cardId == 4 && DrawCards.drawablecardforPlayer)
        {
            Debug.Log("Karta s ID 0 je v dropzóne. Vykonávam špecifickú akciu.");
        }
        else if (cardId == 4 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Karta s ID 0 je v dropzóne. Vykonávam špecifickú akciu.");
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
            DrawCards.drawablecardforEnemy = true;
            DrawCards.drawablecardforPlayer = false;
        }
        else if (cardId == 6 && DrawCards.drawablecardforEnemy)
        {
            DrawCards.drawablecardforPlayer = true;
            DrawCards.drawablecardforEnemy = false;
        }
        else if (cardId == 7 && DrawCards.drawablecardforPlayer)
        {
            if (lastDroppedCardId == 7 && lastDroppedCardByPlayer)
            {
               
                TakeRandomCardFromEnemy();
            }

            lastDroppedCardByPlayer = true;
        }
        else if (cardId == 7 && DrawCards.drawablecardforEnemy)
        {
            if (cardId == 7 && lastDroppedCardByEnemy)
            {
                TakeRandomCardFromPlayer();
            }
            lastDroppedCardByEnemy = true;
        }

    }


    private void TakeRandomCardFromEnemy()
    {
        if (DrawCards.cardsEnemyDeck.Count > 0)
        {
            Debug.Log("BeremKartu7");
            int randomIndex = Random.Range(0, DrawCards.cardsEnemyDeck.Count);
            GameObject randomCard = DrawCards.cardsEnemyDeck[randomIndex];
            DrawCards.cardsPlayerDeck.Add(randomCard);
            DrawCards.cardsEnemyDeck.Remove(randomCard);
            Destroy(randomCard);
            
            lastDroppedCardByPlayer = false;
        }
    }

    private void TakeRandomCardFromPlayer()
    {
        if (DrawCards.cardsPlayerDeck.Count > 0)
        {
            int randomIndex = Random.Range(0, DrawCards.cardsPlayerDeck.Count);
            GameObject randomCard = DrawCards.cardsPlayerDeck[randomIndex];
            DrawCards.cardsEnemyDeck.Add(randomCard);
            DrawCards.cardsPlayerDeck.Remove(randomCard);
            lastDroppedCardByEnemy = false;

        }
    }


}

