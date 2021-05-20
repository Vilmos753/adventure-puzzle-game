using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class Coloring : MonoBehaviour
{
    private Material mat;
    [SerializeField] private TextMeshPro redString;
    [SerializeField] private TextMeshPro greenString;
    [SerializeField] private TextMeshPro blueString;

    public static Color color;

    private float red;
    private float green;
    private float blue;

    void Start()
    {
        mat = GetComponent<Renderer>().materials[1];
    }
    void Update()
    {
        red = float.Parse(redString.text);
        green = float.Parse(greenString.text);
        blue = float.Parse(blueString.text);
        color = new Color(red / 255f, green / 255f, blue / 255f);
        mat.SetColor("_EmissionColor", color);
    }
}
