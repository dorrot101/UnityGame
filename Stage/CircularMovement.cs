using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    Vector2 center;
    RotateObject rotateobject;
    LineRenderer lineRenderer;
    Camera cam;
    KeyGenerator keyGenerator;

    Vector3[] points;
    int pointNum;

    float frequency = 30;
    float radius = 30.0f;
    float deg;
    float lapsedTime;

    // Start is called before the first frame update
    void Awake()
    {

        //
        center = new Vector2(0, 0);
        deg = 0;
        lapsedTime = 0;

        rotateobject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();
        //Initialize lineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 100;
        lineRenderer.useWorldSpace = false;
        //initialize cam var with main Camera
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
         lapsedTime += Time.deltaTime;

            var circumference = 2.0f * Mathf.PI;

            deg = lapsedTime * (circumference / frequency) % circumference;

            var xpos = Mathf.Cos(deg);
            var ypos = Mathf.Sin(deg);

            transform.position = radius * new Vector2(xpos, ypos);

            ShowBoundary();
        //ShowOuter();
    }

    void ShowOuter()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if(viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            
            //var temp = (Vector2)(transform.position - rotateobject.transform.position).normalized;
            //Vector3 indicator =  cam.ViewportToWorldPoint(temp);
            //endpoint.transform.position = indicator;
            //Debug.Log(temp);
        }

    }

    private void ShowBoundary()
    {
        pointNum = 100;
        lineRenderer.loop = true;
        points = new Vector3[pointNum];

        for (int i = 0; i < pointNum; i++)
        {
            var line = -transform.position * i / pointNum;

            points[i] = new Vector3(line.x, line.y , -1);
        }
        lineRenderer.material.color = Color.white;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        lineRenderer.SetPositions(points);
    }
}
