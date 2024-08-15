using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameState gameState;
    private GameObject player;
    private Transform checkpoint;
    public delegate void EventHandler();
    public event EventHandler LevelCompletedEvent;
    public event EventHandler LevelFailedEvent;
    private int levelTime;

    private GameManager() {

    }

    private void CompleteLevel() {
        LevelCompletedEvent?.Invoke();
    }

    private void LevelFailed() {
        LevelFailedEvent?.Invoke();
        player.SetActive(false);
    }

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else 
            Destroy(gameObject);
    }

    void Start() {
        
    }

    void Update() {
        switch(gameState) {
            case GameState.levelFinished:
                CompleteLevel();
                break;
            
            case GameState.playerDied:
                if(checkpoint != null) {
                    player.SetActive(false);
                    StartCoroutine(RespawnPlayer());
                    gameState = GameState.ongoing;
                }
                break;
            
            case GameState.timeIsUp:
                LevelFailed();
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        gameState = GameState.ongoing;
        if(!SceneManager.GetActiveScene().name.Equals("MainMenu")) {
            player = GameObject.FindGameObjectWithTag("Player");
            checkpoint = GameObject.FindGameObjectWithTag("start").transform;

            if(SceneManager.GetActiveScene().name.Equals("level1")) {
                levelTime = 60;
            }
            else if(SceneManager.GetActiveScene().name.Equals("level2")) {
                levelTime = 60;
            }
            else if(SceneManager.GetActiveScene().name.Equals("level2")) {
                levelTime = 120;
            }
        }
    }

    public GameState getGameState() {
        return this.gameState;
    }

    public void setGameState(GameState gameState) {
        this.gameState = gameState;
    }

    public void setCheckPoint(Transform checkpoint) {
        this.checkpoint = checkpoint;
    }

    private IEnumerator RespawnPlayer() {
        yield return new WaitForSeconds(1.5f);
        player.transform.position = checkpoint.position;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public int getLevelTime() {
        return levelTime;
    }
}

public enum GameState {
    ongoing,
    levelFinished,
    playerDied,
    timeIsUp
}


