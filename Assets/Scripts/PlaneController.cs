using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded;
    public float rotateSpeed;

    // Awake functie word geroepen voordat het spel word gestart
    void Awake()
    {
        // neem de Rigibody van het vliegtuigobject en geeft het een naam
        rb = gameObject.GetComponent<Rigidbody2D>();

        // zet de snelheid op 0
        speed = 0f;
    }

    // FixedUpdate word elke gefixeerde frame uitgevoerd doormiddel van de frame-rate tijdens de game om de physics beter te behandelen
    void FixedUpdate()
    {
        Acceleration();
        LimitSpeed();
        HandleRotation();
        LimitRotation();

        HandleDropping();
    }

    void Acceleration()
    {
        // toetsen om de snelheid te verhogen of verlagen
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            speed++;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            speed--;
        }
        // altijd force blijven gebruiken zodat  het vliegtuig altijd in beweging blijft
        rb.AddRelativeForce(transform.right * speed * 10f * Time.deltaTime);
    }

    void LimitSpeed()
    {
        // snelheid limiteren
        if (speed >= 100f)
        {
            speed = 100f;
        }
        else if (speed <= 0)
        {
            speed = 0f;
        }
    }

    void HandleRotation()
    {
        // als de linkerpijltoets of A word ingedrukt voert de volgende code uit
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            // check of het vliegtuig op de grond is
            if(isGrounded)
            {
                // als het vliegtuig contact maakt met de grond verhoogt de snelheid van rotatie om te helpen opstijgen
                rb.rotation += rotateSpeed + 4;
            } else
            {
                // als het vliegtuig niet in contact is met de grond behoud hij de normale rotatie snelheid
                rb.rotation += rotateSpeed;
            }

        // als de rechterpijltoets of D word ingedrukt voert de volgende code uit 
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // check of het vliegtuig van de grond af is
            if (!isGrounded)
            {
                // het vliegtuig mag alleen deze kant op roteren als hij van de grond af is.
                rb.rotation -= rotateSpeed;
            }
        }
    }

    void LimitRotation()
    {
        // als het vliegtuig een bepaalde rotatie heeft of verder is dan die rotatie
        if (rb.rotation >= 30f)
        {
            // ressetten naar gespecificeerde rotatie
            rb.SetRotation(30f);
        } else if (rb.rotation <= -10f)
        {
            rb.SetRotation(-10f);
        }
    }

    void HandleDropping()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // als het vliegtuig in contact is met een object met de "Ground tag"
        if (other.gameObject.CompareTag("Ground"))
        {
            // zet de boolean "isGrounded" of waar
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // als het vliegtuig van contact af gaat met een object met de "Ground tag"
        if (other.gameObject.CompareTag("Ground"))
        {
            // zet de boolean "isGrounded" of vals
            isGrounded = false;
        }
    }
}
