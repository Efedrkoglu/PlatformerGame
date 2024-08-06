using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    protected virtual void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            GameManager.instance.setGameState(GameState.playerDied);
        }
    }
}
