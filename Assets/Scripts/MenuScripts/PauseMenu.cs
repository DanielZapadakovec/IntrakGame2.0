using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public AudioSource pausesound;
    public AudioSource gamesound;
    public bool isPaused;
    public GameObject PauseButton;


    // Start is called before the first frame update
    void Start()
    {
        pausesound = GameObject.Find("PauseSound").GetComponent<AudioSource>();
        gamesound = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused )
            {
                ResumeGame();

            }
            else
            {
                PauseGame();

            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        gamesound.Pause();
        pausesound.Play();
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            gamesound.Play();
            pausesound.Pause();
        PauseButton.SetActive(true);

    }
}
