using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraToObject : MonoBehaviour
{
    [SerializeField] private GameObject triggerToDestroy;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject snapObject;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private TextMeshProUGUI useTextMeshPro;
    [SerializeField] private GameObject characterCameraLocation; // karakter kamerája helyén lévő empty object
    [SerializeField] private Vector3 LookDirection;

    private bool cameraOnObject = false;
    private Vector3 location;
    private bool isTriggered;
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
        location = snapObject.transform.position;
        originalText = useTextMeshPro.text;
    }
    
    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E) && !cameraOnObject)
        {
            snapToObject();
        }

        if (isTriggered && Input.GetKeyDown(KeyCode.Escape) && cameraOnObject)
        {
            snapToPlayer();
        }
    }

    public void snapToObject()
    {
        Cursor.lockState = CursorLockMode.Confined;
        character.GetComponent<PlayerMovement>().enabled = false;
        playerCamera.GetComponent<MouseLook>().enabled = false;
        playerCamera.transform.SetPositionAndRotation(location,Quaternion.Euler(LookDirection));
        useTextMeshPro.text = "Nyomd meg az Esc-et a kilépéshez";
        cameraOnObject = true;
    }

    public void snapToPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        character.GetComponent<PlayerMovement>().enabled = true;
        playerCamera.GetComponent<MouseLook>().enabled = true;
        playerCamera.transform.SetPositionAndRotation(characterCameraLocation.transform.position,Quaternion.Euler(LookDirection));
        useTextMeshPro.text = originalText;
        cameraOnObject = false;
        panel.SetActive(false);
        if (triggerToDestroy != null)
        {
            if (CodeLock.codePass)
            {
                Destroy(triggerToDestroy);
            }
        }
    }
}
