using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start word uitgevoerd op de eerste frame van het spel
    void Start()
    {
        // direction is de variabel die word gebruikt om een directie te krijgen en te gebruiken in 1 lijn
        var direction = transform.right + -transform.up;

        // Neem de rigibody van de bom en geef het een kracht in de directie die is aangegeven
        GetComponent<Rigidbody2D>().AddForce(direction * 20f, ForceMode2D.Impulse);

    }
}
