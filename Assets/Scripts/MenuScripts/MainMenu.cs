using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject MainPanel;
    public GameObject TutorialPanel;
    public GameObject AskingPanel;
    public bool isInSettingPanel;

    private void Start()
    {
        isInSettingPanel = false;
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
        SceneManager.LoadScene(0);
   
    }
    public void Lore_Button()
    {
        SceneManager.LoadScene(2);
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

}
