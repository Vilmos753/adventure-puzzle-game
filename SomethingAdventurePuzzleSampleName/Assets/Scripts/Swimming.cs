using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    
    
    public LayerMask waterMask;
    public Transform waterCheck;
    private bool isFullyInWater;
    private bool isInWater;
    private float waterDistance = 0.3f;
    private float restrictJumpDistance = 1f;
    void Update()
    {
        var position = waterCheck.position;
        isFullyInWater = Physics.CheckSphere(position, waterDistance, waterMask);
        
        isInWater = Physics.CheckSphere(position, restrictJumpDistance, waterMask);
        PlayerMovement.isFullyInWater = isFullyInWater;

        if (isInWater)
        {
            PlayerMovement.speed = 1f;
            PlayerMovement.jumpHeight = 0f;
        }
        else
        {
            PlayerMovement.speed = 3f;
            PlayerMovement.jumpHeight = 1.5f;
        }
        
    }
}
