using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    private int codeLength;
    private int placeInCode;

    public string code;
    public string attemptedCode;

    public Transform toOpen;

    private void Start()
    {
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if (attemptedCode == code)
        {
            StartCoroutine(Open());
        }
        else
        {
            Debug.Log("Rossz kód");
        }
    }

    IEnumerator Open()
    {
        toOpen.Rotate(new Vector3(0, 90, 0), Space.World);

        yield return new WaitForSeconds(4);
        
        toOpen.Rotate(new Vector3(0, -90, 0), Space.World);
    }

    public void SetValue(string value)
    {
        Debug.Log(value);
        placeInCode++;

        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        if (placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
