using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject unmuteButton;

    private void Start() {
        unmuteButton.SetActive(false);
    }

    public void PlayGame() {
        if(PauseMenu.isPaused)
            PauseMenu.isPaused = false;
            
        SceneManager.LoadScene("level1");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Mute() {
        Debug.Log("muted");
        unmuteButton.SetActive(true);
        muteButton.SetActive(false);
    }

    public void Unmute() {
        Debug.Log("unmuted");
        muteButton.SetActive(true);
        unmuteButton.SetActive(false);
    }
}
