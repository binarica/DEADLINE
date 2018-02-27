using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private Light flashlight;
    float fireRate = 0.25f;
    float nextFire = 0f;

    void Awake()
    {
        flashlight = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetButton("Fire2") || Input.GetKeyDown(KeyCode.F))
            ToggleLight();
    }

    void ToggleLight()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            flashlight.enabled = flashlight.enabled ? false : true;
        }
    }
}