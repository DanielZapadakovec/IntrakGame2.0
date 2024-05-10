using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject WaitPanel;
    public bool NeedToWaitPanel;


    // Update is called once per frame
    void Update()
    {
        if (NeedToWaitPanel == true)
        {
            WaitPanel.SetActive(true);
        }
    }

    public void Resume()
    {
        WaitPanel.SetActive(false);
        NeedToWaitPanel = false;
    }
}
