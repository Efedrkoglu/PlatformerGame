using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_spike_wall : trap
{
    private Animator animator;
    [SerializeField] private float animationSpeed = 1f;
    private void Start() {
        animator = GetComponent<Animator>();
        animator.speed = animationSpeed;
    }

    protected override void OnCollisionEnter(Collision other) {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            GameManager.instance.setGameState(GameState.playerDied);
        }
    }
}
