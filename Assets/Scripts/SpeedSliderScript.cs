using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSliderScript : MonoBehaviour
{
    private Slider slider;
    private PlaneController plane;
    public float currentSpeed;

    // Start word uitgevoerd op de eerste frame van het spel
    void Start()
    {
        // het ophalen van de slider component
        slider = GetComponent<Slider>();

        // het ophalen van de spelerscript op de speler
        plane = FindObjectOfType<PlaneController>();
    }

    // Update word elke frame uitgevoerd
    void Update()
    {
        // geeft de snelheid van het vliegtuig de naam "currentSpeed"
        currentSpeed = plane.speed;

        // zet de value van de slider op de snelheid van het vliegtuig
        slider.value = currentSpeed;
    }
}
