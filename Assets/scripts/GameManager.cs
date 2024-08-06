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
    private string[] scenes;
    private int currentSceneIndex;
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
        scenes = new string[SceneManager.sceneCountInBuildSettings];

        for(int i = 0; i < scenes.Length; i++) {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        }
        currentSceneIndex = 0;
    }

    void Update()
    {
        switch(gameState) {
            case GameState.levelFinished:
                LoadNextLevel();
                break;
            
            case GameState.playerDied:
                RestartCurrentLevel();
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        this.gameState = GameState.ongoing;  
    }

    public void setGameState(GameState gameState) {
        this.gameState = gameState;
    }

    private void LoadNextLevel() {
        currentSceneIndex++;

        if(currentSceneIndex == scenes.Length)
            currentSceneIndex -= 1;
        
        SceneManager.LoadScene(scenes[currentSceneIndex]);
    }

    private void RestartCurrentLevel() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}

public enum GameState {
    ongoing,
    levelFinished,
    playerDied
}


