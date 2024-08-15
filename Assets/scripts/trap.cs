using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] protected ParticleSystem explosion;
    private AudioSource audioSource;

    protected virtual void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    protected virtual void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            PlayPopSound();
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            GameManager.instance.setGameState(GameState.playerDied);
        }
    }

    protected void PlayPopSound() {
        audioSource.Play();
    }
}
