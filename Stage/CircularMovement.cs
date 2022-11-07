using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    Vector2 center;
    RotateObject rotateobject;
    LineRenderer lineRenderer;

    Vector3[] points;
    int pointNum;

    float frequency = 30;
    float radius = 50.0f;
    float deg;
    float lapsedTime;

    // Start is called before the first frame update
    void Awake()
    {
        center = new Vector2(0, 0);
        deg = 0;
        lapsedTime = 0;

        rotateobject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 100;
        lineRenderer.useWorldSpace = false;

        ShowBoundary();
    }
    private void FixedUpdate()
    {
        lapsedTime += Time.deltaTime;

        var circumference = 2.0f * Mathf.PI;

        deg = lapsedTime * (circumference/frequency) % circumference;

        var xpos = Mathf.Cos(deg);
        var ypos = Mathf.Sin(deg);

        transform.position = radius * new Vector2(xpos, ypos);

        ShowBoundary();
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
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.SetPositions(points);
    }
}
