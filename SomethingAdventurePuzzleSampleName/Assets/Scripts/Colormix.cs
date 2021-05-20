using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colormix : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool isTriggered;
    private bool isPressed = false;
    private bool animationStarted = false;

    [SerializeField] private GameObject kevero;
    [SerializeField] private GameObject channel1;
    [SerializeField] private GameObject channel2;
    [SerializeField] private GameObject channel3;
    [SerializeField] private GameObject channel4;
    [SerializeField] private GameObject lampa1;
    [SerializeField] private GameObject ajto1;
    [SerializeField] private GameObject lampa2;
    [SerializeField] private GameObject ajto2;
    private void OnTriggerEnter(Collider other)
    {
        panel.SetActive(true);
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
        isTriggered = false;
    }

    private void Update()
    {
        if (isTriggered && !isPressed)
        {
            if (isTriggered && Input.GetKeyDown(KeyCode.E))
            {
                isPressed = true;
            }
        }

        if (isPressed && !animationStarted)
        {
            animationStarted = true;

            kevero.GetComponent<Renderer>().material.SetColor("_EmissionColor", Coloring.color);
            channel1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Coloring.color);
            channel2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Coloring.color);
            channel3.GetComponent<Renderer>().material.SetColor("_EmissionColor", Coloring.color);
            channel4.GetComponent<Renderer>().material.SetColor("_EmissionColor", Coloring.color);

            StartCoroutine(Animation());
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(1);
        //Keverő anim
        float keveroelapsedTime = 0;
        float keverowaitTime = 4f;
        var keverocurrentPos = kevero.transform.position;
        var keveroGotoposition = keverocurrentPos;
        keveroGotoposition.y += 0.9f;

        while (keveroelapsedTime < keverowaitTime)
        {
            kevero.transform.position = Vector3.Lerp(keverocurrentPos, keveroGotoposition, (keveroelapsedTime / keverowaitTime));
            keveroelapsedTime += Time.deltaTime;

            yield return null;
        }  
        
        kevero.transform.position = keveroGotoposition;
        yield return new WaitForSeconds(1);
        
        //Channel1 anim
        
        float channel1ElapsedTime = 0;
        float Channel1waitTime = 3f;
        var channel1CurrentPos = channel1.transform.position;
        var channel1Gotoposition = channel1CurrentPos;
        channel1Gotoposition.x += 2.29f;

        var channel1StartScale = channel1.transform.localScale;
        var channel1TargetScale = channel1StartScale;
        channel1TargetScale.x += 6;

        while (channel1ElapsedTime < Channel1waitTime)
        {
            channel1.transform.position = Vector3.Lerp(channel1CurrentPos, channel1Gotoposition, (channel1ElapsedTime / Channel1waitTime));
            channel1.transform.localScale = Vector3.Lerp(channel1StartScale, channel1TargetScale, (channel1ElapsedTime / Channel1waitTime));
            channel1ElapsedTime += Time.deltaTime;

            yield return null;
        }
 
        channel1.transform.position = channel1Gotoposition;
        
        //Channel2 anim

        channel2.SetActive(true);
        float channel2ElapsedTime = 0;
        float channel2WaitTime = 3f;

        var channel2StartScale = channel2.transform.localScale;
        var channel2TargetScale = channel2StartScale;
        channel2TargetScale.x += 7.9f;
        
        while (channel2ElapsedTime < channel2WaitTime)
        {
            channel2.transform.localScale = Vector3.Lerp(channel2StartScale, channel2TargetScale, (channel2ElapsedTime / channel2WaitTime));
            channel2ElapsedTime += Time.deltaTime;
            
            yield return null;
        }

        //Channel3&4 anim
        
        channel3.SetActive(true);
        channel4.SetActive(true);
        
        float channel34ElapsedTime = 0;
        float waitTime = 3f;
        var channel3CurrentPos = channel3.transform.position;
        var channel4CurrentPos = channel4.transform.position;
        
        var channel3Gotoposition = channel3CurrentPos;
        var channel4Gotoposition = channel4CurrentPos;
        channel3Gotoposition.x += 1.5f;
        channel4Gotoposition.x += 1.5f;

        var channel3StartScale = channel3.transform.localScale;
        var channel4StartScale = channel4.transform.localScale;
        
        var channel3TargetScale = channel3StartScale;
        var channel4TargetScale = channel4StartScale;
        channel3TargetScale.x += 3;
        channel4TargetScale.x += 3;
        
        while (channel34ElapsedTime < waitTime)
        {
            channel3.transform.position = Vector3.Lerp(channel3CurrentPos, channel3Gotoposition, (channel34ElapsedTime / waitTime));
            channel3.transform.localScale = Vector3.Lerp(channel3StartScale, channel3TargetScale, (channel34ElapsedTime / waitTime));
            
            channel4.transform.position = Vector3.Lerp(channel4CurrentPos, channel4Gotoposition, (channel34ElapsedTime / waitTime));
            channel4.transform.localScale = Vector3.Lerp(channel4StartScale, channel4TargetScale, (channel34ElapsedTime / waitTime));
            channel34ElapsedTime += Time.deltaTime;
            
            yield return null;
        }  
        
        channel3.transform.position = channel3Gotoposition;
        channel4.transform.position = channel4Gotoposition;

        if (lampa1.GetComponent<Renderer>().materials[1].GetColor("_EmissionColor") == Coloring.color)
        {
            lampa1.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.green);
            var ajtoRotation = ajto1.transform.rotation;
            var ajtoRotationDest = ajtoRotation;
            ajtoRotationDest.y -= 90f;

            var ajtoWaitTime = 2f;
            var ajtoElapsedTime = 0f;
            
            
            while (ajtoElapsedTime < ajtoWaitTime)
            {
                ajto1.transform.rotation = Quaternion.Lerp(ajtoRotation, ajtoRotationDest, (ajtoElapsedTime / ajtoWaitTime));
                ajtoElapsedTime += Time.deltaTime;
            }
                
        }
        else
        {
            lampa1.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.red);
        }
        
        Debug.Log(lampa2.GetComponent<Renderer>().materials[1].GetColor("_EmissionColor"));
        
        if (lampa2.GetComponent<Renderer>().materials[1].GetColor("_EmissionColor") == Coloring.color)
        {
            lampa2.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.green);
            
            var ajtoRotation = ajto2.transform.rotation;

            var ajtoWaitTime = 2f;
            var ajtoElapsedTime = 0f;
            while (ajtoElapsedTime < ajtoWaitTime)
            {
                ajto2.transform.rotation = Quaternion.RotateTowards(ajtoRotation, Quaternion.Euler(0, -90, 0), 90*(ajtoElapsedTime/ajtoWaitTime));
                ajtoElapsedTime += Time.deltaTime;
                yield return null;
            }

            
        }
        else
        {
            lampa2.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.red);
        }
        
        
        yield return null;
    }

}
