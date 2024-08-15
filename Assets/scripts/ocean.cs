using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocean : trap
{
    protected override void Start() {
        base.Start();
    }
    protected override void OnCollisionEnter(Collision other)
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            PlayPopSound();
            Instantiate(base.explosion, other.gameObject.transform.position, Quaternion.identity);
            GameManager.instance.setGameState(GameState.playerDied);
        }
    }
}
