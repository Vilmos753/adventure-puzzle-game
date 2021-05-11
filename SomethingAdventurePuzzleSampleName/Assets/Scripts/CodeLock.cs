using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    private int codeLength;
    private int placeInCode;

    public string code;
    public string attemptedCode;

    [SerializeField] private TextMeshPro screenText;
    public Transform toOpen;

    public static bool codePass;

    private void Start()
    {
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if (attemptedCode == code)
        {
            screenText.text = "Jó";
            toOpen.Rotate(new Vector3(0, 90, 0), Space.World);
            codePass = true;
        }
        else
        {
            screenText.text = "Rossz";
        }
    }

    public void SetValue(string value)
    {
        
        placeInCode++;

        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
            screenText.text = attemptedCode;
        }

        if (placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
