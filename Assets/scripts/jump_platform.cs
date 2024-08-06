using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_platform : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float force;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            animator.SetBool("playerEntered", true);
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));
        }
    }
}
