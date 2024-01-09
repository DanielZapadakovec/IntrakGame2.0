using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject MainPanel;
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
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu_Button()
    {
        SceneManager.LoadScene(0);
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
