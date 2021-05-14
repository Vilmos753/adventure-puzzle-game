using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private bool isTriggered;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI useTextMeshPro;
    [SerializeField] private Transform doorToClose;
    public WaterRise waterRise;
    void Start()
    {
        useTextMeshPro.text = "Nyomd meg az E-t";
    }
    
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

    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(false);
            doorToClose.Rotate(new Vector3(0, -90, 0), Space.World);
            waterRise.Rise();
            Destroy(this);
        }

    }
}
