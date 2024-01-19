using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySideScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 startPosition;
    public DrawCards drawCards;
    public Vector3 targetPositionForEnemy;
    public Vector3 startPositionForEnemy;
    public GameObject MySide;
    public GameObject EnemySide;

    public void Start()
    {
        drawCards = GameObject.Find("DrawCardButton").GetComponent<DrawCards>();
    }

    // Metóda, ktorá sa volá po kliknutí na tlaèidlo
    public void MoveObject()
    {
        if (drawCards.switchtoeplayerside == true)
        {
            MySide.transform.position = startPosition;
        }
        else
        {
            MySide.transform.position = targetPosition;
        }
        if (drawCards.switchtoenemyside == true)
        {
            EnemySide.transform.position = startPosition;
        }
        else
        {
            EnemySide.transform.position = targetPosition;
        }

    }
}
