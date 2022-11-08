using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guage : MonoBehaviour
{
    GameObject guage;
    BoxCollider2D boxCollider2d;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody2d;

    int pointNum;
    Vector3[] points;
    float boundaryWidth;
    float boundaryHeight;

    // Start is called before the first frame update
    void Awake()
    {
        guage = GameObject.Find("Guage");
        boxCollider2d = GetComponent<BoxCollider2D>();
        lineRenderer = guage.AddComponent<LineRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        lineRenderer.positionCount = 399;

        boundaryWidth = boxCollider2d.size.x;
        boundaryHeight = boxCollider2d.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowBoundary();
        ShowSector();
    }

    private void ShowBoundary()
    {
        pointNum = 100;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = false;
        points = new Vector3[pointNum * 4];

        for (int i = 0; i < pointNum; i++)
        {
            var pointPerHeight = i * (boundaryHeight/pointNum);
            var pointPerWidth = i * (boundaryWidth /pointNum);

            points[i]       = new Vector3(-boundaryWidth / 2 + pointPerWidth, boundaryHeight/2 ,-1);
            points[99 + i]  = new Vector3(boundaryWidth / 2, boundaryHeight / 2 - pointPerHeight, -1);
            points[199 + i] = new Vector3(boundaryWidth / 2 - pointPerWidth, -boundaryHeight / 2, -1);
            points[299 + i] = new Vector3(-boundaryWidth / 2 , -boundaryHeight / 2 + pointPerHeight, -1);
        }

        lineRenderer.material.color = Color.white;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        lineRenderer.SetPositions(points);
    }

    private void ShowSector()
    {

    }
}
