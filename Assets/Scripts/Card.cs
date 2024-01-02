using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public string cardDescription;
    public Sprite spriteImage;

    public Card()
    {

    }

    public Card (int Id, string CardName, string CardDescription, Sprite SpriteImage)
    {
        this.id = Id;
        this.cardName = CardName;
        this.cardDescription = CardDescription;
        this.spriteImage = SpriteImage;
    }
}
