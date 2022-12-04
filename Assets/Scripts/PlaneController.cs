using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private float speed;
    public float rotateSpeed;

    // Awake functie word geroepen voordat het spel word gestart
    void Awake()
    {
        // neem de Rigibody van het vliegtuigobject en geeft het een naam
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0).gameObject;

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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rb.rotation += rotateSpeed;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.rotation -= rotateSpeed;
        }
    }

    void LimitRotation()
    {
        if (rb.rotation >= 30f)
        {
            rb.SetRotation(30f);
        } else if (rb.rotation <= -10f)
        {
            rb.SetRotation(-10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
