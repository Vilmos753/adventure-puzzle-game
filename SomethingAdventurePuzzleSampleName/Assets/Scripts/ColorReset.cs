using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorReset : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject kevero;
    [SerializeField] private GameObject channel1;
    [SerializeField] private GameObject channel2;
    [SerializeField] private GameObject channel3;
    [SerializeField] private GameObject channel4;
    
    [SerializeField] private GameObject lampa1;
    [SerializeField] private GameObject lampa2;
    
    private Vector3 keveroPosition;
    
    private Vector3 channel1Position;
    private Vector3 channel1Scale;
    
    private Vector3 channel2Position;
    private Vector3 channel2Scale;
    
    private Vector3 channel3Position;
    private Vector3 channel3Scale;
    
    private Vector3 channel4Position;
    private Vector3 channel4Scale;
    
    private bool isTriggered = false;

    private Color lampa1Col;
    private Color lampa2Col;
    
    void Start()
    {
        keveroPosition = kevero.transform.position;
        
        channel1Position = channel1.transform.position;
        channel1Scale = channel1.transform.localScale;
        
        channel2Position = channel2.transform.position;
        channel2Scale = channel2.transform.localScale;
        
        channel3Position = channel3.transform.position;
        channel3Scale = channel3.transform.localScale;
        
        channel4Position = channel4.transform.position;
        channel4Scale = channel4.transform.localScale;

        lampa1Col = lampa1.GetComponent<Renderer>().materials[1].GetColor("_EmissionColor");
        lampa2Col = lampa2.GetComponent<Renderer>().materials[1].GetColor("_EmissionColor");
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        panel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
        isTriggered = false;
    }

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            
            channel2.SetActive(false);
            channel3.SetActive(false);
            channel4.SetActive(false);

            Colormix.isPressed = false;
            Colormix.animationRunning = false;
            
            lampa1.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", lampa1Col);
            lampa2.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", lampa2Col);
            
            kevero.transform.position = keveroPosition;

            channel1.transform.position = channel1Position;
            channel1.transform.localScale = channel1Scale;
            
            
            channel2.transform.position = channel2Position;
            channel2.transform.localScale = channel2Scale;
            
            channel3.transform.position = channel3Position;
            channel3.transform.localScale = channel3Scale;
            
            channel4.transform.position = channel4Position;
            channel4.transform.localScale = channel4Scale;
        }
    }
}
