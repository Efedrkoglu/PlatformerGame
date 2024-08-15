using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] confetti;
    void Start()
    {
        GameManager.instance.LevelCompletedEvent += OnLevelCompleted;
    }

    private void OnDestroy() {
        if(GameManager.instance != null) {
            GameManager.instance.LevelCompletedEvent -= OnLevelCompleted;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            GameManager.instance.setGameState(GameState.levelFinished);
        }
    }

    private void OnLevelCompleted() {
        StartCoroutine(PlayConfetti());
    }

    private IEnumerator PlayConfetti() {
        for(int i = 0; i < confetti.Length; i++) {
            confetti[i].Play();
        }

        yield return new WaitForSeconds(1.5f);

        for(int i = 0; i < confetti.Length; i++) {
            confetti[i].Stop();
        }
    }
}
