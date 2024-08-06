using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_spike : trap
{
    [SerializeField] private float interval;
    private Animator animator;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= interval) {
            time += Time.deltaTime;
        }
        else {
            animator.SetBool("isWaiting", false);
        }

    }
}
