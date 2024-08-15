using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelFailedMenu;

    private void Start() {
        levelFailedMenu.SetActive(false);
        GameManager.instance.LevelFailedEvent += OnLevelFailed;
    }

    private void OnDestroy() {
        if(GameManager.instance != null) {
            GameManager.instance.LevelFailedEvent -= OnLevelFailed;
        }
    }

    public void Replay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnLevelFailed() {
        levelFailedMenu.SetActive(true);
    }
}
