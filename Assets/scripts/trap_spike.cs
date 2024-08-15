using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_spike : trap
{
    [SerializeField] private float interval;
    private Animator animator;
    private float time = 0;
    
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

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
