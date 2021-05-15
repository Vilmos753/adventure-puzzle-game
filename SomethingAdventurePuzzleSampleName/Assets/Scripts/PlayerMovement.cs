using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public static float speed = 3f;
    public float gravity = -9.81f;
    public static float jumpHeight = 1.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isRunning;
    public static bool isFullyInWater;
    
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && !isRunning)
        {
            isRunning = true;
            speed *= 3;
        }

        if (!Input.GetKey(KeyCode.LeftShift) && isRunning)
        {
            speed /= 3;
            isRunning = false;
        }
        
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        if (jumpHeight == 0)
        {
            gravity = 0;
            if (isFullyInWater)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    velocity.y = 1f;
                }
                else
                {
                    velocity.y = 0f;
                }
            }
            else
            {
                velocity.y = 0f;
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity.y = -1f;
            }
            
        }
        else
        {
            gravity = -9.81f;
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
            
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            } 
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
