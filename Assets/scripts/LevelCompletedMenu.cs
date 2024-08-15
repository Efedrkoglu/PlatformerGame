using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletedMenu;
    private string currentLevel;

    private void Start() {
        levelCompletedMenu.SetActive(false);
        currentLevel = SceneManager.GetActiveScene().name;
        GameManager.instance.LevelCompletedEvent += OnLevelCompleted;
    }

    private void OnDestroy() {
        if(GameManager.instance != null) {
            GameManager.instance.LevelCompletedEvent -= OnLevelCompleted;
        }
    }

    public void NextLevel() {
        if(currentLevel.Equals("level1")) {
            SceneManager.LoadScene("level2");
        }
        else if(currentLevel.Equals("level2")) {
            SceneManager.LoadScene("level3");
        }
        else {
            SceneManager.LoadScene("level3");
        }
    }

    public void Replay() {
        SceneManager.LoadScene(currentLevel);
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnLevelCompleted() {
        levelCompletedMenu.SetActive(true);
    }

}
