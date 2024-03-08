using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject MyTurn;
    public GameObject EnemyTurn;
    public Sprite cards40;
    public Sprite cards30;
    public Sprite cards20;
    public Sprite cards10;
    public List<Sprite> carddeckimages = new List<Sprite>();
    public Image DrawCardsImage;


    // positions from myscript
    public Vector3 targetPosition;
    public Vector3 startPosition1;
    public Vector3 targetPositionForEnemy;
    public Vector3 startPositionForEnemy;
    public GameObject MySide;
    public GameObject EnemySide;


    public Text turntext;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CanBeDrawed = true;
        DrawCardsImage.GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        if (drawablecardforEnemy == true )
        {
            ShowBackOfCard(cardsEnemyDeck, false);
            ShowBackOfCardforPlayer(cardsPlayerDeck, true);
            MySide.transform.position = targetPosition;
            EnemySide.transform.position = startPosition1;
            if (StartGameWasExecuted) { turntext.text = ("Enemy Turn"); }
        }
        else if (drawablecardforPlayer == true )
        {
            ShowBackOfCard(cardsEnemyDeck, true);
            ShowBackOfCardforPlayer(cardsPlayerDeck, false);
            MySide.transform.position = startPosition1;
            EnemySide.transform.position = targetPosition;
            if (StartGameWasExecuted) { turntext.text = ("Player Turn"); }
        }
    }

    public void CheckDeckCount()
    {
        if (cardsInDeck.Count == 40)
        {
            DrawCardsImage.GetComponent<Image>().sprite = cards40;
        }
        if (cardsInDeck.Count == 30)
        {
            DrawCardsImage.GetComponent<Image>().sprite = cards30;
        }
        if (cardsInDeck.Count == 20)
        {
            DrawCardsImage.GetComponent<Image>().sprite = cards20;
        }
        if (cardsInDeck.Count == 10)
        {
            DrawCardsImage.GetComponent<Image>().sprite = cards10;
        }
    }

    public void OnClick()
    {
        if (CanBeDrawed == true)
        {
            CheckDeckCount();
            if (cardsInDeck.Count > 0 && drawablecardforPlayer == true)
            {
                GameObject card = Instantiate(cardsInDeck[cardsInDeck.Count - 1], new Vector2(0, 0), Quaternion.identity);
                card.transform.SetParent(PlayerArea.transform, false);

                cardsPlayerDeck.Add(card);

                cardsInDeck.RemoveAt(cardsInDeck.Count - 1);
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
                Debug.Log("Bal��ek je pr�zdny.");
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
        CanBeDrawed = false;
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
        for (int i = 0; i < 1; i++) //tu do bud�cna, sa d� �e spawne iba tolko vychovavatelov kolko je hr��ov -1
        {
            cardsInDeck.Add(vychovavatelprefab);
        }
        ShuffleCardsInDeck();
        StartGameWasExecuted = true;
        CanBeDrawed = true;
        drawablecardforPlayer = true;

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
    void UpdateCardPositions()
    {
        // Assuming a horizontal layout for simplicity
        float xOffset = 2.0f; // Adjust this value based on your desired spacing

        // Update positions for cards in the player area
        for (int i = 0; i < cardsPlayerDeck.Count; i++)
        {
            cardsPlayerDeck[i].transform.position = new Vector2(i * xOffset, 0f);
        }

        // Update positions for cards in the enemy area
        for (int i = 0; i < cardsEnemyDeck.Count; i++)
        {
            cardsEnemyDeck[i].transform.position = new Vector2(i * xOffset, 0f);
        }
    }




}
