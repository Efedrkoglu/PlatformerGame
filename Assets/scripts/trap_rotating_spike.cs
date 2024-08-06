using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_rotating_spike : trap
{

    protected override void OnCollisionEnter(Collision other) {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            GameManager.instance.setGameState(GameState.playerDied);
        }
    }
}
