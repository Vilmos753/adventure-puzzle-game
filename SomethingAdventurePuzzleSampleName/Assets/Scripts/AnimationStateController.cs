using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isRunning;
    private int isWalkingHash;
    private int isRunningHash;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWalking && Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            animator.SetBool(isWalkingHash, isWalking);
        }
        
        if (isWalking && !Input.GetKey(KeyCode.W))
        {
            isWalking = false;
            animator.SetBool(isWalkingHash, isWalking);
        }
        
        // Running
        
        if (!isRunning && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            isRunning = true;
            animator.SetBool(isRunningHash, isRunning);
        }
        
        if (isRunning && (!Input.GetKey(KeyCode.LeftShift) || !Input.GetKey(KeyCode.W)))
        {
            isRunning = false;
            animator.SetBool(isRunningHash, isRunning);
        }
        
    }
}
