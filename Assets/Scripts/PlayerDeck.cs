using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;

        for (int i = 0; i < 56; i++)
        {
            x = Random.Range(0,6);
            deck[i] = CardDatabase.cardList[x];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
