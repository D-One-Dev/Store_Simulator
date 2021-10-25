using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    //audio mixer
    [SerializeField] private AudioMixer AM;
    //resolution dropdown
    [SerializeField] private Dropdown resolutionDropdown;
    //fullscreen toggle
    [SerializeField] private Toggle fullscreenToggle;
    //list of available resolutions
    private Resolution[] resolutions;
    private void Start()
    {
        //setting fullscreen toggle on/off
        fullscreenToggle.isOn = Screen.fullScreen;
        //getting list of available resolutions
        resolutions = Screen.resolutions;
        //clear the dropdown
        resolutionDropdown.ClearOptions();
        //IDK
        List<string> options = new List<string>();
        //creating a list of resolutions
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height + " " + resolutions[i].refreshRate + " Hz";
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                //setting current resolution
                currentResolutionIndex = i;
            }
        }
        //adding resolutions to the dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        //setting the audio mixer volume
        AM.SetFloat("MasterVolume", volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        //setting fulscreen on/off
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        //changing the resolution
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
