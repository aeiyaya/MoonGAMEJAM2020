using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{

    private Light flashLight;

    private float batteryLevel = 100f;
    public float BatteryLevel { get { return batteryLevel; } }

    private bool flashLightOn = false;

    private void Start()
    {
        flashLight = GetComponent<Light>();
    }

    public void Update()
    {
        // Inputs
        // Turn Flashlight on and off
        if (Input.GetKeyDown(KeyCode.E)) {
            flashLightOn = !flashLightOn;
            flashLight.enabled = flashLightOn;
        }

        

    }
    
}
