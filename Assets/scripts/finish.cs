using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    private Collider col;
    void Start()
    {
        col = GetComponent<Collider>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            GameManager.instance.setGameState(GameState.levelFinished);
        }
    }
}
