using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Slider : MonoBehaviour
{
    private float factor = 5.0f;
     
    private Vector3 v3StartPos;  // Initial position of object
    private Vector3 v3DownPos;   // Initial position of the mouse in world coordinates
    private float fZMap; // Base Z distance to use in conversion
    // minimum 0 és max 25
    
    private void OnMouseDown()
    {
        v3StartPos = transform.localPosition;
        Vector3 v3T = Camera.main.WorldToScreenPoint(v3StartPos);
        fZMap = v3T.z;
        v3DownPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, fZMap);
        v3DownPos = Camera.main.ScreenToWorldPoint(v3DownPos);
    }
    
    

    private void OnMouseDrag(){
        Vector3 v3T = new Vector3(Input.mousePosition.x, Input.mousePosition.y, fZMap);
        v3T = Camera.main.ScreenToWorldPoint(v3T);
       
        Vector3 v3T2 = v3StartPos;    
        v3T2 = v3StartPos;
        v3T2.x = v3T2.x + (v3T.x - v3DownPos.x);
        v3T2.z = v3T2.z + (v3T.y - v3DownPos.y) * factor;

        if (v3T2.z >= 0)
        {
            v3T2.z = 0;
        }

        if (v3T2.z <= -25)
        {
            v3T2.z = -25;
        }

        
         
        transform.localPosition = v3T2; 
        
    }

    
}
