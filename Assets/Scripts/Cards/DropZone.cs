using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public List<GameObject> discardPile = new List<GameObject>();
    private float cardOffset = 0.1f;

    private Vector3 lastCardPosition;

    void Start()
    {
        lastCardPosition = transform.position;
    }

    public void AddToDiscardPile(GameObject card)
    {
        discardPile.Add(card);
        card.transform.position = lastCardPosition;
        float randomRotation = Random.Range(0f, 360f);
        card.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);

        lastCardPosition.y += cardOffset;
    }
}