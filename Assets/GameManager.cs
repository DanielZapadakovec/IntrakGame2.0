using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasCardWithID0 = false;
    public bool hasCardWithID1 = false;

    public bool hasCardWithID0Enemy;
    public bool hasCardWithID1Enemy;
    public GameObject endGamePanel;
    public DrawCards drawCards;
    public DropZone dropZone;
    public DragDrop dragDrop;
    public List<GameObject> topThree = new List<GameObject>();
    public GameObject DropZone;

    public GameObject buttonToGetBackCards;
    private void Start()
    {
      drawCards = GameObject.Find("DrawCardButton").GetComponent<DrawCards>();
      dropZone = GameObject.Find("DropZone").GetComponent<DropZone>();
    }
    public void Update()
    {
        CheckGameOver();

    }

    public void CheckGameOver()
    {
        foreach (var card in DrawCards.cardsPlayerDeck)
        {
                CardIdentity cardIdentity = card.GetComponent<CardIdentity>();

                if (cardIdentity != null)
                {
                    int cardId = cardIdentity.ID;

                    if (cardId == 0)
                    {
                        hasCardWithID0 = true;
                    }
                    else if (cardId == 1)
                    {
                        hasCardWithID1 = true;
                    }
                }
        }
        foreach (var card in DrawCards.cardsEnemyDeck)
        {
            CardIdentity cardIdentity2 = card.GetComponent<CardIdentity>();

            if (cardIdentity2 != null)
            {
                int cardId = cardIdentity2.ID;

                if (cardId == 0)
                {
                    hasCardWithID0Enemy = true;
                }
                else if (cardId == 1)
                {
                    hasCardWithID1Enemy = true;
                }
            }
        }

        // Ak hráè nemá žiadnu kartu s ID 0, prehráva
        if (hasCardWithID1 && !hasCardWithID0 || !hasCardWithID0Enemy && hasCardWithID1Enemy)
        {
            drawCards.CanBeDrawed = false;
            endGamePanel.SetActive(true);
        }


        if (hasCardWithID0 && hasCardWithID1 || hasCardWithID0Enemy && hasCardWithID1Enemy)
        {
            drawCards.CanBeDrawed = false;
            int indexCardWithID0 = DrawCards.cardsPlayerDeck.FindIndex(card => card.GetComponent<CardIdentity>().ID == 0);

            if (indexCardWithID0 != -1)
            {
                GameObject cardWithID0 = DrawCards.cardsPlayerDeck[indexCardWithID0];
                dropZone.discardPile.Add(cardWithID0);
                DrawCards.cardsPlayerDeck.RemoveAt(indexCardWithID0);
                Destroy(cardWithID0);
            }

            GameObject cardWithID1 = DrawCards.cardsPlayerDeck.Find(card => card.GetComponent<CardIdentity>().ID == 1);
            if (cardWithID1 != null)
            {
                drawCards.cardsInDeck.Insert(0, cardWithID1);
                DrawCards.cardsPlayerDeck.Remove(cardWithID1);
                Destroy(cardWithID1);
            }

            drawCards.CanBeDrawed = true;
        }
    }
    public void GetBackCardsFromCamerasCard()
    {
        buttonToGetBackCards.SetActive(false);
        DropZone.SetActive(true);
        for (int i = topThree.Count - 1; i >= 0; i--)
        {
            drawCards.cardsInDeck.Insert(drawCards.cardsInDeck.Count, topThree[i]);
            topThree.Remove(topThree[i]);
        }
        foreach (Transform child in drawCards.ViewPlayerArea.transform)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("boli vratene");
        drawCards.CanBeDrawed = true;
        dragDrop.areinViewArea = false;
        topThree.Clear();

    }

}
