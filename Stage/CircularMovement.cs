using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircularMovement : MonoBehaviour
{
    Vector2 center;
    RotateObject rotateobject;
    LineRenderer lineRenderer;
    Camera cam;
    KeyGenerator keyGenerator;

    Vector3[] points;
    int pointNum;

    float frequency = 10;
    float radius = 100.0f;
    float deg = 0;
    float lapsedTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        center = new Vector2(0, 0);
        rotateobject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();

        if (SceneManager.GetActiveScene().name.Equals("Tutorial")) radius = 40.0f;

        //Initialize lineRenderer
        InitializeLineRenderer(100, 0.05f, 0.05f);
        
        //initialize cam var with main Camera
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        lapsedTime += Time.deltaTime;
        Move();
        ShowBoundary();
        //ShowOuter();
    }

    void InitializeLineRenderer(int positioncount, float startwidth, float endwidth)
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = positioncount;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.material.color = Color.white;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = startwidth;
        lineRenderer.endWidth = endwidth;
        pointNum = lineRenderer.positionCount;
        points = new Vector3[pointNum];
    }

    void Move()
    {
        var circumference = 2.0f * Mathf.PI;

        deg = lapsedTime * (circumference / frequency) % circumference;

        var xpos = Mathf.Cos(deg);
        var ypos = Mathf.Sin(deg);

        transform.position = radius * new Vector2(xpos, ypos);
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
        for (int i = 0; i < pointNum; i++)
        {
            var line = -transform.position * i / pointNum;

            points[i] = new Vector3(line.x, line.y , -1);
        }

        lineRenderer.SetPositions(points);
    }
}
