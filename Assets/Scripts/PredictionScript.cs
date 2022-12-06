using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionScript : MonoBehaviour
{
    private LineRenderer line;
    private GameObject plane;
    private Vector2 startPoint;
    private Vector2 endPoint;

    // Start word uitgevoerd op de eerste frame van het spel
    void Start()
    {
        // de LineRenderer ophalen
        line = GetComponent<LineRenderer>();

        // het aantal lijnen aangeven voor de lijn
        line.positionCount = 2;

        // het vliegtuig ophalen
        plane = GameObject.FindGameObjectWithTag("Player");

        // de lijn automatisch uitschakelen wanneer de game wordt gestart
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // het begin van de lijn ophalen (namelijk de positie van het vliegtuig)
        startPoint = plane.transform.position;

        // het eindpunt van de lijn ophalen (de positie van het vliegtuig zodat de lijn het vlieguig volgt maar dan richting de grond
        endPoint = new Vector2(startPoint.x + 14, startPoint.y - 20);

        // het startpunt plaatsen van de lijn
        line.SetPosition(0, startPoint);

        // het eindpunt plaatsen van de lijn
        line.SetPosition(1, endPoint);
    }
}
