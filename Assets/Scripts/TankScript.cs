using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : EnemyScript
{
    // Start word uitgevoerd op de eerste frame als het spel start
    void Start()
    {
        // de functie gebruiken van de inherited enemyscript
        GetRigibody();

        // Zet de snelheid op 10f
        this.EnemySpeed = 5f;
    }

    // FixedUpdate word elke gefixeerde frame uitgevoerd om zo beter te werken met physics
    void FixedUpdate()
    {
        // de functie gebruiken van de inherited enemyscript
        EnemyMovement();
    }
}
