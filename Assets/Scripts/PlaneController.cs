using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LineRenderer predictLine;
    public float rotateSpeed;
    public GameObject bomb;

    // Awake functie word geroepen voordat het spel word gestart
    void Awake()
    {
        // neem de Rigibody van het vliegtuigobject en geeft het een naam
        rb = gameObject.GetComponent<Rigidbody2D>();

        // zet de snelheid op 0
        speed = 0f;
    }

    // Start word uitgevoerd op de eerste frame van het spel
    void Start()
    {
        // De line renderer ophalen van de prediction line om het richten van de bommen te versimpelen
        predictLine = gameObject.transform.GetChild(0).GetComponent<LineRenderer>();
    }

    // FixedUpdate word elke gefixeerde frame uitgevoerd doormiddel van de frame-rate tijdens de game om de physics beter te behandelen
    void FixedUpdate()
    {
        Acceleration();
        LimitSpeed();
        HandleRotation();
        LimitRotation();
    }

    // Update word elke frame uitgevoerd
    void Update()
    {
        // Handledropping zit in update omdat deze niet gebasseerd word door physics en altijd uitgevoerd moet worden
        HandleDropping();
    }

    // functie voor de controle van de snelheid
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
        rb.AddRelativeForce(10f * speed * Time.deltaTime * transform.right);
    }

    // functie voor het limiteren van de snelheid
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

    // functie voor de rotatie van het vliegtuig
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

    // functie voor het limiteren van de rotatie
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

    // functie voor het droppen van bommen
    void HandleDropping()
    {
        // voer volgende code uit als de spatieknop wordt ingehouden en het vliegtuig van de grond af is
        if (Input.GetKey(KeyCode.Space) && !isGrounded) 
        {
            // laat de lijn zien om te richten
            predictLine.enabled = true;
        } else
        {
            // zet de lijn weer uit
            predictLine.enabled = false;
        }

        // voer volgende code uit als de spatieknop word losgelaten en het vliegtuig van de grond af is
        if (Input.GetKeyUp(KeyCode.Space) && !isGrounded)
        {
            // maak en plaats de prefab van een bom onder het vliegtuigje;
            Instantiate(bomb, new Vector2(rb.transform.position.x, rb.transform.position.y - 1), Quaternion.identity);
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
