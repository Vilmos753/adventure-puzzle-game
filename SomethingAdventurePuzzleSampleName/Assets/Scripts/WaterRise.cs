using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{

    private bool startWaterRise = false;
    Vector3 position;
    private float target;
    public void Rise()
    {
        startWaterRise = true;
    }

    private void Start()
    {
        position = transform.position;
        target = position.y + 3;
    }

    private void Update()
    {
        if (startWaterRise)
        {
            
            position = Vector3.Lerp(position, new Vector3(position.x, target, position.z), Time.deltaTime);
            transform.position = position;
        }
    }
}
