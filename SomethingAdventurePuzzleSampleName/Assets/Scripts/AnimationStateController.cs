using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isSwimming;
    [SerializeField] private bool isSwimmingIdle;
    private int isWalkingHash;
    private int isRunningHash;
    private int isSwimmingIdleHash;
    private int isSwimmingHash;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask waterMask;
    [SerializeField] private Transform waterCheck;
    [SerializeField] private float groundDistance = 0.4f;
    private bool isGrounded;
    private bool isInWater;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isSwimmingIdleHash = Animator.StringToHash("isSwimmingIdle");
        isSwimmingHash = Animator.StringToHash("isSwimming");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isInWater = Physics.CheckSphere(groundCheck.position, groundDistance, waterMask);

        isSwimmingIdle = false;
        animator.SetBool(isSwimmingIdleHash, isSwimmingIdle);

        if (isGrounded)
        {
            isSwimmingIdle = false;
            animator.SetBool(isSwimmingIdleHash, isSwimmingIdle);
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

        if (isInWater && !isGrounded)
        {
            isSwimmingIdle = true;
            animator.SetBool(isSwimmingIdleHash, isSwimmingIdle);
        }
        
        
    
        
        
            


    }
}
