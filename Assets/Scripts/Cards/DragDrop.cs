using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<GameObject> topThree = new List<GameObject>();

    void Start()
    {
        Canvas = GameObject.Find("MainCanvas");
        drawCards = GameObject.Find("DrawCardButton").GetComponent<DrawCards>();


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
        if (!isDraggable) return;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;

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
            Debug.Log("Karta s ID 0 je v dropz�ne. Vykon�vam �pecifick� akciu.");
        }
        else if (cardId == 0 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Karta s ID 0 je v dropz�ne. Vykon�vam �pecifick� akciu.");
        }
        else if (cardId == 2 && DrawCards.drawablecardforPlayer)
        {
            drawCards.CanBeDrawed = false;
            Debug.Log("Hr�� si pozrie prv� tri karty z bal��ka.");
            for (int i = 0; i < 3 && i < drawCards.cardsInDeck.Count; i++)
            {
                topThree.Add(drawCards.cardsInDeck[i]);
                GameObject card = Instantiate(drawCards.cardsInDeck[drawCards.cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
                card.transform.SetParent(drawCards.ViewPlayerArea.transform, false);
                drawCards.cardsInDeck.RemoveAt(drawCards.cardsInDeck.Count-1);
            }
            Debug.Log("boli vzate");
            WaitForBackCards();
            foreach (Transform child in drawCards.ViewPlayerArea.transform)
            {
                Destroy(child.gameObject);
            }
            for (int i = topThree.Count - 1; i >= 0; i--)
            {
                drawCards.cardsInDeck.Insert(0, topThree[i]);

            }
            Debug.Log("boli vratene");
            drawCards.CanBeDrawed = true;

        }
        else if (cardId == 2 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Hr�� si pozrie prv� tri karty z bal��ka.");
        }
        else if (cardId == 3 && DrawCards.drawablecardforPlayer)
        {
            Debug.Log("Karta s ID 0 je v dropz�ne. Vykon�vam �pecifick� akciu.");
        }
        else if (cardId == 3 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Karta s ID 0 je v dropz�ne. Vykon�vam �pecifick� akciu.");
        }
        else if (cardId == 4 && DrawCards.drawablecardforPlayer)
        {
            Debug.Log("Karta s ID 0 je v dropz�ne. Vykon�vam �pecifick� akciu.");
        }
        else if (cardId == 4 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Karta s ID 0 je v dropz�ne. Vykon�vam �pecifick� akciu.");
        }
        else if (cardId == 5 && DrawCards.drawablecardforPlayer)
        {
            Debug.Log("Karty boli zamie�ane");
            drawCards.ShuffleCardsInDeck();
        }
        else if (cardId == 5 && DrawCards.drawablecardforEnemy)
        {
            Debug.Log("Karty boli zamie�ane");
            drawCards.ShuffleCardsInDeck();
        }
        else if (cardId == 6 && DrawCards.drawablecardforPlayer)
        {
            DrawCards.drawablecardforPlayer = false;
            DrawCards.drawablecardforEnemy = true;
        }
        else if (cardId == 6 && DrawCards.drawablecardforEnemy)
        {
            DrawCards.drawablecardforPlayer = true;
            DrawCards.drawablecardforEnemy = false;
        }
        else if (cardId == 7 && DrawCards.drawablecardforPlayer)
        {
        }
        else if (cardId == 7 && DrawCards.drawablecardforEnemy)
        {

        }
    }


    IEnumerator WaitForBackCards()
    {
        yield return new WaitForSeconds(5f);
    }

}
