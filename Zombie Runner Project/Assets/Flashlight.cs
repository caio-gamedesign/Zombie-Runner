using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float dimmerDownRate = .1f;
    [SerializeField] float angleRate = 1f;
    [SerializeField] float minimumAngle = 40f;

    private new Light light;

    [SerializeField] private float maximumAngle = 70f;
    [SerializeField] private float dimmerUpRate = 2f;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        DimDown();
    }

    private void DimDown()
    {
        if (light.spotAngle > minimumAngle)
        {
            light.spotAngle -= angleRate * Time.deltaTime;
        }

        light.intensity -= dimmerDownRate * Time.deltaTime;
    }

    public void DimUp()
    {
        light.spotAngle = maximumAngle;
        light.intensity += dimmerUpRate;
    }
}
