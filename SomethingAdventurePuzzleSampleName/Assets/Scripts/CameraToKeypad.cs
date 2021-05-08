using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToKeypad : MonoBehaviour
{
    private bool isTriggered;
    public GameObject KeypadCamera;
    public GameObject panel;
    public GameObject character;
    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        panel.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        panel.SetActive(false);
    }

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
           KeypadCamera.SetActive(true);
           character.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
