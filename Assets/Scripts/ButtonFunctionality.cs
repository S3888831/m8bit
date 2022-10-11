// automatically imported modules from Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // used to specify which scene you are being redirected to
using UnityEngine.UI; // used to access elements from within projects (UI)

public class ButtonFunctionality : MonoBehaviour {
    public Slider AudioSlider; // [SerializeField] just means its a private var
                                         // but can be accessed from within Unity Project

    // This function is called when game starts
    void Start() { 
        // If Players have no saved data, set audio volume to 100% (1) 
        // else, load previous data
        if (PlayerPrefs.HasKey("AudioVal") == true) {
            Load();
        }

        else {
            PlayerPrefs.SetFloat("AudioVal", 1);
        }
    }

    // This function will be called when the play button is pressed and direct user
    // to the next relevant scene
    public void PlayButton() {
        SceneManager.LoadScene("Modes Scene"); // write Gamemodes Scene name in text
    }

    // Sets the volume when the Slider is used
    public void ChangeVolume() {
        AudioListener.volume = AudioSlider.value;
        Save();
    }

    // Updated slider based on previous session's Slider data
    public void Load() {
        AudioSlider.value = PlayerPrefs.GetFloat("AudioVal");
    }

    // Saves current session Slider data to be used in future sessions
    public void Save() {
        PlayerPrefs.SetFloat("AudioVal", AudioSlider.value);
    }

    // Quits the application
    public void QuiteGame() {
        Application.Quit();
    }
}
