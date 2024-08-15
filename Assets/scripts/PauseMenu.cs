using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public static bool isPaused = false;
    private void Start() {
        pauseMenu.SetActive(false);
    }

    private void Update() {
        if(isPaused) {
            PauseGame();
        }
        else {
            ResumeGame();
        }
    }

    private void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ResumeGame() {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    private void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    private void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }
}
