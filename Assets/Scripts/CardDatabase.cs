using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

     void Awake()
    {
        cardList.Add(new Card (0, "Vychovavatel", "Vymysli si v�hovorku in�� �a vyhod�.", Resources.Load<Sprite>("Vychovavatel") ));
        cardList.Add(new Card (1, "V�hovorka", "Vyhov�ranie sa ku agres�vnemu vychov�vate�ovi.", Resources.Load<Sprite>("Vyhovorka")));
        cardList.Add(new Card (2, "Presko�", "Okam�ite ukon�i svoj �ah", Resources.Load<Sprite>("Presko�")));
        cardList.Add(new Card (3, "�e", "Zastav� ak�ko�vek akciu.", Resources.Load<Sprite>("�e")));
        cardList.Add(new Card(4, "Za�to�", "N�sleduj�ci hr�� si berie 2 karty.", Resources.Load<Sprite>("Za�to�")));
        cardList.Add(new Card(5, "Pozri kamery", "Pod�vaj sa na tri karty z bal��ka.", Resources.Load<Sprite>("PozriKamery")));
        cardList.Add(new Card(6, "L�skavos�", "Vyberte si hr��a aby v�m dal kartu.", Resources.Load<Sprite>("L�skavos�")));
    }
}
