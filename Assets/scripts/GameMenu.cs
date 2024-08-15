using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;

    private void Start() {
        
    }

    private void Update() {
        if(!PauseMenu.isPaused) {
            gameMenu.SetActive(true);
        }
    }

    public void PauseGame() {
        PauseMenu.isPaused = true;
        gameMenu.SetActive(false);
    }
}
