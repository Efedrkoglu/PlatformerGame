using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private Text timer;
    private float time;

    private void Start() {
        time = GameManager.instance.getLevelTime();
        timer.text = time.ToString();
    }

    private void Update() {
        if(!PauseMenu.isPaused) {
            gameMenu.SetActive(true);
        }

        if(GameManager.instance.getGameState() == GameState.levelFinished) {
            gameMenu.SetActive(false);
        }

        if(time > 0) {
            if(GameManager.instance.getGameState() != GameState.levelFinished) {
                time -= Time.deltaTime;
            }
        }
        else {
            GameManager.instance.setGameState(GameState.timeIsUp);
            gameMenu.SetActive(false);
        }

        timer.text = ((int)time).ToString();
    }

    public void PauseGame() {
        PauseMenu.isPaused = true;
        gameMenu.SetActive(false);
    }
}
