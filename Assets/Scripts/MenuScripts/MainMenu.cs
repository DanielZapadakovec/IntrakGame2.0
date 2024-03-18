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
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        isInSettingPanel = false;

        SetMusicVolume();
        SetMasterVolume();
        SetSFXVolume();
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
        DrawCards.NeedToWaitPanel = false;
    }
    public void SetMasterVolume()
    {
        float Master_volume = masterSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(Master_volume) * 20);
    }
    public void SetSFXVolume()
    {

        float SFX_volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(SFX_volume) * 20);
    }
    public void SetMusicVolume()
    {
        float Music_volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(Music_volume) * 20);
    }
}
