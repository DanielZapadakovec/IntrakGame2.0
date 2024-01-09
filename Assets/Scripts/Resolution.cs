using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions = new List<Resolution>();

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        if (resolutions != null && resolutions.Length > 0)
        {
            int currentRefreshRate = Screen.currentResolution.refreshRate;

            foreach (var resolution in resolutions)
            {
                if (resolution.refreshRate == currentRefreshRate)
                {
                    filteredResolutions.Add(resolution);
                }
            }

            List<string> options = new List<string>();
            int currentResolutionIndex = 0;
            for (int i = 0; i < filteredResolutions.Count; i++)
            {
                string resolutionOption = $"{filteredResolutions[i].width}x{filteredResolutions[i].height} {filteredResolutions[i].refreshRate}Hz";
                options.Add(resolutionOption);

                if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
        else
        {
            Debug.LogError("No resolutions found!");
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex >= 0 && resolutionIndex < filteredResolutions.Count)
        {
            Resolution resolution = filteredResolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, true);
        }
        else
        {
            Debug.LogWarning("Invalid resolution index!");
        }
    }
}
