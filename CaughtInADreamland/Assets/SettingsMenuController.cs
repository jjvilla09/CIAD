using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;


public class SettingsMenuController : MonoBehaviour
{
    [SerializeField] private FadeTransitionController ftc;

    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;

    [Header("Resolution")]
    [SerializeField] TMP_Dropdown resDropdown;
    Resolution[] resolutions;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Toggle vSyncToggle;

    [Header("Helper Text")]
    [SerializeField] GameObject helperText;
    [Tooltip("(in seconds)")]
    [SerializeField] float helperTextDuration;
    
    void Start() {
        GetResolutionSettings();
        LoadSavedSettings();
        ChooseResolution();
    }

    public void Back() {
        LoadSavedSettings();
        ftc.FadeToColor("MainMenu");
    }

    void LoadSavedSettings() {
        // Load Saved Settings //

        // Audio Settings //
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");


        // Display Settings //
        // Resolution //
        resDropdown.value = PlayerPrefs.GetInt("ResolutionDropdownIndex");

        if(PlayerPrefs.GetInt("IsFullscreen") == 1) {
            fullscreenToggle.isOn = true;
        } else {
            fullscreenToggle.isOn = false;
        }

        // vSync //
        if(PlayerPrefs.GetInt("IsVSync") == 1) {
            vSyncToggle.isOn = true;
        } else {
            vSyncToggle.isOn = false;
        }


    }

    public void SetMasterVolume() {
        audioMixer.SetFloat("MasterVolume", ConvertToDecibel(masterVolumeSlider.value));
        //PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void SetMusicVolume() {
        audioMixer.SetFloat("MusicVolume", ConvertToDecibel(musicVolumeSlider.value));
        //PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void SetSFXVolume() {
        audioMixer.SetFloat("SFXVolume", ConvertToDecibel(SFXVolumeSlider.value));
        //PlayerPrefs.SetFloat("SFXVolume", SFXVolumeSlider.value);
    }

    float ConvertToDecibel(float sliderValue) {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }

    void GetResolutionSettings() {
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        for(int i = 0; i<resolutions.Length; i++) {
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
        }
    }

    public void ChooseResolution() {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, fullscreenToggle.isOn);
        // PlayerPrefs.SetInt("ResolutionDropdownIndex", resDropdown.value);

        // if(fullscreenToggle.isOn) {
        //     PlayerPrefs.SetInt("IsFullscreen", 1);
        // } else {
        //     PlayerPrefs.SetInt("IsFullscreen", 0);
        // }
    }

    public void SetVSync() {
        if(vSyncToggle.isOn) {
            QualitySettings.vSyncCount = 1;
        } else {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void ApplySettings() {
        // Audio Settings //
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolumeSlider.value);

        // Display Settings //
        // Resolution //
        PlayerPrefs.SetInt("ResolutionDropdownIndex", resDropdown.value);

        if(fullscreenToggle.isOn) {
            PlayerPrefs.SetInt("IsFullscreen", 1);
        } else {
            PlayerPrefs.SetInt("IsFullscreen", 0);
        }

        // vSync //
        if(vSyncToggle.isOn) {
            PlayerPrefs.SetInt("IsVSync", 1);
        } else {
            PlayerPrefs.SetInt("IsVSync", 0);
        }


        // save message
        PromptSaveSuccessMessage();
    }

    void PromptSaveSuccessMessage() {
        StartCoroutine(PromptSaveSuccessMessageRoutine());
        IEnumerator PromptSaveSuccessMessageRoutine(){
            helperText.SetActive(true);
            yield return new WaitForSeconds(helperTextDuration);
            helperText.SetActive(false);
        }
    }
}
