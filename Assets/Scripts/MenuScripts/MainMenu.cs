using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject MainPanel;
    public GameObject TutorialPanel;
    public GameObject AskingPanel;
    public GameObject WaitPanel;
    public bool isInSettingPanel;
    public GameObject MySide;
    public GameObject EnemySide;
    public GameManager gameManager;
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        isInSettingPanel = false;

        SetMusicVolume();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isInSettingPanel)
            {
                MainPanel.SetActive(true);
                SettingPanel.SetActive(false);
            }
        }
    }
    public void PlayGame()
    {
        AskingPanel.SetActive(true);
    }
    public void ExitTutorial()
    {
        AskingPanel.SetActive(false);
    }
    public void InsistOnPlaying()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Tutorial() 
    {
        TutorialPanel.SetActive(true);
        AskingPanel.SetActive(false);
        MainPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
        public void Menu_Button()
        {
            DrawCards.cardsPlayerDeck.Clear();
            DrawCards.cardsEnemyDeck.Clear();
            gameManager.topThree.Clear();
            Destroy(MySide);
            Destroy(EnemySide);
            SceneManager.LoadScene(0);
        }


    public void Lore_Button()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Setting_Button()
    {
            SettingPanel.SetActive(true);
            MainPanel.SetActive(false);
            isInSettingPanel=true;

    }

    public void BackToMenuFromSetting()
    {
        if (isInSettingPanel)
        {
            MainPanel.SetActive(true);
            SettingPanel.SetActive(false);
        }
    }
    public void Resume()
    {
        WaitPanel.SetActive(false);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20);
    }

}
