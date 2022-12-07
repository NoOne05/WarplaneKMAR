using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRB;
    public GameObject fireParticle;
    public float EnemySpeed;

    // Deze functie haalt de rigibody van het huidige object op en maakt hem zichtbaar voor inheritance
    protected virtual void GetRigibody()
    {
        // automatisch de rigibody van het huidige object ophalen.
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Deze functie regelt de snelheid en beweging van het voertuig en maakt hem zichtbaar voor inheritance
    protected virtual void EnemyMovement()
    {
        // Relative force toepassen op basis van de snelheid die is aangegeven met "EnemySpeed"
        enemyRB.AddRelativeForce(transform.right * EnemySpeed);
    }

    // Deze functie chect voor collision met de bomb object
    private void OnCollisionEnter2D(Collision2D other)
    {
        // deze if statement bekijkt of het object de tag "Bomb" heeft
        if (other.gameObject.CompareTag("Bomb"))
        {
            // een clone van de vuur particle prefab plaatsen op de positie van het voertuig
            Instantiate(fireParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            // het voertuig stoppen
            EnemySpeed = 0;
        }
    }
}
