using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextWriter : MonoBehaviour
{

     Text txt;
    string story;
    public float waitforTypeSeconds = 0.125f;
    public DrawCards drawCards;

    void Awake()
    {
        drawCards = GameObject.Find("DrawCardButton").GetComponent<DrawCards>();
        txt = GetComponent<Text>();
        story = txt.text;
        txt.text = "";
        StartCoroutine("PlayText");
    }

    public void Update()
    {
        
    }

    public IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(waitforTypeSeconds);
        }
    }

}