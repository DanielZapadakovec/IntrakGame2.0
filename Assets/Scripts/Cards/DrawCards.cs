using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public List<GameObject> cardsInDeck = new List<GameObject>();
    public GameObject PlayerArea;
    public GameObject ViewPlayerArea; 
    public static List<GameObject> cardsPlayerDeck = new List<GameObject>();
    public static List<GameObject> cardsEnemyDeck = new List<GameObject>();
    public bool StartGameWasExecuted;
    public static bool drawablecardforPlayer = true;
    public static bool drawablecardforEnemy;
    public GameObject EnemyArea;
    public GameObject ViewEnemydArea;
    public GameObject vychovavatelprefab;
    public GameObject BackOfCardPrefab;
    public GameManager gameManager;
    public bool CanBeDrawed = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CanBeDrawed = true;
}

    // Update is called once per frame
    void Update()
    {
        if (drawablecardforEnemy == true )
        {
            ShowBackOfCard(cardsEnemyDeck, false);
            ShowBackOfCardforPlayer(cardsPlayerDeck, true);
        }
        else if (drawablecardforPlayer == true )
        {
            ShowBackOfCard(cardsEnemyDeck, true);
            ShowBackOfCardforPlayer(cardsPlayerDeck, false);
        }
    }
    
    public void OnClick()
    {
        if (CanBeDrawed == true)
        {
            if (cardsInDeck.Count > 0 && drawablecardforPlayer == true)
            {
                GameObject card = Instantiate(cardsInDeck[cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
                card.transform.SetParent(PlayerArea.transform, false);

                cardsPlayerDeck.Add(card);

                cardsInDeck.RemoveAt(cardsInDeck.Count - 1);
                if (gameManager.hasCardWithID0 == false)
                {

                }
                drawablecardforPlayer = false;
                drawablecardforEnemy = true;
            }
            else if (cardsInDeck.Count > 0 && drawablecardforEnemy == true)
            {
                GameObject card = Instantiate(cardsInDeck[cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
                card.transform.SetParent(EnemyArea.transform, false);

                cardsEnemyDeck.Add(card);

                cardsInDeck.RemoveAt(cardsInDeck.Count - 1);

                drawablecardforPlayer = true;
                drawablecardforEnemy = false;
            }
            else if (cardsPlayerDeck.Count < 1)
            {
                Debug.Log("Balíèek je prázdny.");
            }
        }

    }
    public void ShuffleCardsInDeck()
    {
        int n = cardsInDeck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject value = cardsInDeck[k];
            cardsInDeck[k] = cardsInDeck[n];
            cardsInDeck[n] = value;
        }
    }

    IEnumerator StartGame()
    {
        drawablecardforEnemy = false;
        drawablecardforPlayer = false;
        ShuffleCardsInDeck();
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cardsInDeck[cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(PlayerArea.transform, false);

            cardsPlayerDeck.Add(card);

            cardsInDeck.RemoveAt(cardsInDeck.Count - 1);

            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cardsInDeck[cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(EnemyArea.transform, false);

            cardsEnemyDeck.Add(card);

            cardsInDeck.RemoveAt(cardsInDeck.Count - 1);

            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < 1; i++) //tu do budúcna, sa dá že spawne iba tolko vychovavatelov kolko je hráèov -1
        {
            cardsInDeck.Add(vychovavatelprefab);
        }
        ShuffleCardsInDeck();
        drawablecardforEnemy = false;
        drawablecardforPlayer = true;
        StartGameWasExecuted = true;

    }
    void ShowBackOfCard(List<GameObject> cardsEnemyDeck, bool showBack)
    {
        foreach (var card in cardsEnemyDeck)
        {
            Transform backOfCard = card.transform.Find("CardBack");
            if (backOfCard != null)
            {
                backOfCard.gameObject.SetActive(showBack);
            }
        }
    }
    void ShowBackOfCardforPlayer(List<GameObject> cardsPlayerDeck, bool showBack)
    {
        foreach (var card in cardsPlayerDeck)
        {
            Transform backOfCard = card.transform.Find("CardBack");
            if (backOfCard != null)
            {
                backOfCard.gameObject.SetActive(showBack);
            }
        }
    }



}
