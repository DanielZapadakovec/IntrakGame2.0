using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySideScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 startPosition;
    public DrawCards drawCards;

    public void Start()
    {
        drawCards = GameObject.Find("DrawCardButton").GetComponent<DrawCards>();
    }

    // Metóda, ktorá sa volá po kliknutí na tlaèidlo
    public void MoveObject()
    {
        if (drawCards.switchtoeplayerside == true)
        {
            transform.position = targetPosition;
        }
        if (drawCards.switchtoenemyside == true)
        {
            transform.position = startPosition;
        }

    }
}
