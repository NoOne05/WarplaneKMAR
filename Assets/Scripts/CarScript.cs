using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : EnemyScript
{

    // Start word uitgevoerd op de eerste frame als het spel start
    private void Start()
    {
        // de functie gebruiken van de inherited enemyscript
        GetRigibody();

        // Zet de snelheid op 10f
        this.EnemySpeed = 10f;
    }

    // FixedUpdate word elke gefixeerde frame uitgevoerd om zo beter te werken met physics
    private void FixedUpdate()
    {
        // de functie gebruiken van de inherited enemyscript
        EnemyMovement();
    }
}
