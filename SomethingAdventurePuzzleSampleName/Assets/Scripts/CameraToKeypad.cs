using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class CameraToKeypad : MonoBehaviour
{
    private bool isTriggered;
    public GameObject panel;
    public GameObject character;
    public GameObject snapToKeypad;
    public GameObject cameraa;
    private Vector3 location;
    [SerializeField] private TextMeshProUGUI useTextMeshPro;
    [SerializeField] private GameObject snapToCamera;
    private bool cameraOnKeyPad = false;


    private string originalText;

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

    private void Start()
    {
        location = snapToKeypad.transform.position;
        originalText = useTextMeshPro.text;
    }
    
    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E) && !cameraOnKeyPad)
        {
            snapToCodelock();
        }

        if (isTriggered && Input.GetKeyDown(KeyCode.Escape) && cameraOnKeyPad)
        {
            snapToPlayer();
        }
    }

    public void snapToCodelock()
    {
        Cursor.lockState = CursorLockMode.Confined;
        character.GetComponent<PlayerMovement>().enabled = false;
        cameraa.GetComponent<MouseLook>().enabled = false;
        cameraa.transform.SetPositionAndRotation(location,Quaternion.Euler(new Vector3(0,90,0)));
        useTextMeshPro.text = "Nyomd meg az Esc-et a kilépéshez";
        cameraOnKeyPad = true;
    }

    public void snapToPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        character.GetComponent<PlayerMovement>().enabled = true;
        cameraa.GetComponent<MouseLook>().enabled = true;
        cameraa.transform.SetPositionAndRotation(snapToCamera.transform.position,Quaternion.Euler(new Vector3(0,90,0)));
        useTextMeshPro.text = originalText;
        cameraOnKeyPad = false;
        panel.SetActive(false);
        if (CodeLock.codePass)
        {
            Destroy(this);
        }
    }
}
