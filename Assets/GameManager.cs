using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasCardWithID0 = false;
    public bool hasCardWithID1 = false;
    public GameObject endGamePanel;
    public DrawCards drawCards;
    public DropZone dropZone;
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
            int cardId = card.GetComponent<CardIdentity>().ID;

            if (cardId == 0)
            {
                hasCardWithID0 = true;
            }
            else if (cardId == 1)
            {
                hasCardWithID1 = true;
            }
        }

        // Ak hr�� nem� �iadnu kartu s ID 0, prehr�va
        if (hasCardWithID1 && !hasCardWithID0)
        {
            endGamePanel.SetActive(true);
        }

        if (hasCardWithID0 && hasCardWithID1)
        {
            drawCards.CanBeDrawed = false;
            int indexCardWithID0 = DrawCards.cardsPlayerDeck.FindIndex(card => card.GetComponent<CardIdentity>().ID == 0);

            // Ak sa na�la karta s ID 0, pridajte ju do discardPile, odstr��te ju z cardsPlayerDeck a zni�te ju
            if (indexCardWithID0 != -1)
            {
                GameObject cardWithID0 = DrawCards.cardsPlayerDeck[indexCardWithID0];
                dropZone.discardPile.Add(cardWithID0);
                DrawCards.cardsPlayerDeck.RemoveAt(indexCardWithID0);
                Destroy(cardWithID0);
            }

            // Presun karty s ID 1 sp� do decku a zni�te ju
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


}
