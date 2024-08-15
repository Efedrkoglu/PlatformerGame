using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_spike_wall : trap
{
    private Animator animator;
    [SerializeField] private float animationSpeed = 1f;
    protected override void Start() {
        base.Start();
        animator = GetComponent<Animator>();
        animator.speed = animationSpeed;
    }

    protected override void OnCollisionEnter(Collision other) {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            PlayPopSound();
            Instantiate(base.explosion, other.gameObject.transform.position, Quaternion.identity);
            GameManager.instance.setGameState(GameState.playerDied);
        }
    }
}
