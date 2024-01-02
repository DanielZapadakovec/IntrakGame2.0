using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{

    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public string cardDescription;
    public Sprite spriteImage;

    public Text nameText;
    public Text descriptionText;
    public Image artImage;


    void Start()
    {
        displayCard[0] = CardDatabase.cardList[displayId];
    }

    void Update()
    {
            id = displayCard[0].id;
            cardName = displayCard[0].cardName;
            cardDescription = displayCard[0].cardDescription;
            spriteImage = displayCard[0].spriteImage;

            nameText.text = " " + cardName;
            descriptionText.text = " " + cardDescription;
            artImage.sprite = spriteImage;
    }
}
