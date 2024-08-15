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

    private GameManager() {

    }

    private void CompleteLevel() {
        LevelCompletedEvent?.Invoke();
    } 

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else 
            Destroy(gameObject);

        gameState = GameState.ongoing;
    }

    void Start()
    {
        
    }

    void Update()
    {
        switch(gameState) {
            case GameState.levelFinished:
                CompleteLevel();
                break;
            
            case GameState.playerDied:
                if(checkpoint != null) {
                    player.gameObject.SetActive(false);
                    StartCoroutine(RespawnPlayer());
                    gameState = GameState.ongoing;
                }
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        this.gameState = GameState.ongoing;
        if(!SceneManager.GetActiveScene().name.Equals("MainMenu")) {
            player = GameObject.FindGameObjectWithTag("Player");
            checkpoint = GameObject.FindGameObjectWithTag("start").transform;
        }
    }

    public void setGameState(GameState gameState) {
        this.gameState = gameState;
    }

    public void setCheckPoint(Transform checkpoint) {
        this.checkpoint = checkpoint;
        Debug.Log("Checkpoint set");
    }

    private IEnumerator RespawnPlayer() {
        yield return new WaitForSeconds(1.5f);
        player.transform.position = checkpoint.position;
        player.gameObject.SetActive(true);
        player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}

public enum GameState {
    ongoing,
    levelFinished,
    playerDied,
}


