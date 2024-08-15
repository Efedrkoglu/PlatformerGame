using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField] private Transform checkpointPosition;
    [SerializeField] private ParticleSystem firework;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            GameManager.instance.setCheckPoint(checkpointPosition);
            firework.Play();
        }
    }

}
