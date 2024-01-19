using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySiteScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 startPosition;
    public DrawCards drawCards;

    public void Start()
    {
        drawCards = GameObject.Find("DrawCardButton").GetComponent<DrawCards>();
    }

    // Met�da, ktor� sa vol� po kliknut� na tla�idlo
    public void MoveObject()
    {
        if (drawCards.switchtoenemyside == true)
        {
            transform.position = targetPosition;
        }
        if (drawCards.switchtoeplayerside == true)
        {
            transform.position = startPosition;
        }

    }
}
