using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocean : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            GameManager.instance.setGameState(GameState.playerDied);
        }
    }
}
