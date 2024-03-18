using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class ButtonManager : MonoBehaviour
{

    public List<Image> imageList = new List<Image>();
    public int poradie = 0;
    [SerializeField] AudioSource sfx;
    public AudioClip sfxClip;
    public void Start()
    {
        AddImagesToList();
    }

    public void RandomOne_Button()
    {
        ActivateImageAtIndex(1);
        poradie = 1;
    }
    public void RandomTwo_Button()
    {
        ActivateImageAtIndex(2);
        poradie = 2;
    }
    public void RandomThree_Button()
    {
        ActivateImageAtIndex(3);
        poradie = 3;
    }
    public void Zautoc_Button()
    {
        ActivateImageAtIndex(4);
        poradie = 4;
    }
    public void Zamiesaj_Button()
    {
        ActivateImageAtIndex(5);
        poradie = 5;
    }
    public void Back_Button()
    {
        SceneManager.LoadScene(0);
    }
    void AddImagesToList()
    {
        Image[] images = FindObjectsOfType<Image>();
        foreach (Image image in images)
        {
            imageList.Add(image);
        }
    }
    public void ActivateImageAtIndex(int index)
    {
        DeactivateAllImages();

        if (index >= 0 && index < imageList.Count)
        {
            imageList[index].gameObject.SetActive(true);
            sfx.PlayOneShot(sfxClip);
        }
        else
        {
            Debug.LogError("Index out of range!");
        }
    }
    void DeactivateAllImages()
    {
        imageList[poradie].gameObject.SetActive(false);
    }
}


