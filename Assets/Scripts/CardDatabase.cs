using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

     void Awake()
    {
        cardList.Add(new Card (0, "Vychovavatel", "Vymysli si vıhovorku ináè a vyhodí.", Resources.Load<Sprite>("Vychovavatel") ));
        cardList.Add(new Card (1, "Vıhovorka", "Vyhováranie sa ku agresívnemu vychovávate¾ovi.", Resources.Load<Sprite>("Vyhovorka")));
        cardList.Add(new Card (2, "Preskoè", "Okamite ukonèi svoj ah", Resources.Load<Sprite>("Preskoè")));
        cardList.Add(new Card (3, "Òe", "Zastaví akúko¾vek akciu.", Resources.Load<Sprite>("Òe")));
        cardList.Add(new Card(4, "Zaútoè", "Následujúci hráè si berie 2 karty.", Resources.Load<Sprite>("Zaútoè")));
        cardList.Add(new Card(5, "Pozri kamery", "Podívaj sa na tri karty z balíèka.", Resources.Load<Sprite>("PozriKamery")));
        cardList.Add(new Card(6, "Láskavos", "Vyberte si hráèa aby vám dal kartu.", Resources.Load<Sprite>("Láskavos")));
    }
}
