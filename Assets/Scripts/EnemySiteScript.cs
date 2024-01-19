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


    public void MoveObjectForEnemy()
    {
        if (drawCards.switchtoenemyside == true)
        {
            transform.position = targetPosition;
        }
        else
        {
            transform.position = startPosition;
        }

    }
}
