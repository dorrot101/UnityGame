using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insider : MonoBehaviour
{
    CircleCollider2D circleCollider;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody2d;

    Vector3[] points;

    int pointNum;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        circleCollider = GetComponent<CircleCollider2D>();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 360;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.material.color = Color.red;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        pointNum = lineRenderer.positionCount;
        points = new Vector3[pointNum];
    }

    void FixedUpdate()
    {
        ShowBoundary();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateobject = collision.gameObject.GetComponent<RotateObject>();
        if(rotateobject != null && !rotateobject.isRotate)
        {
            rotateobject.Collide();
        }
    }

    private void ShowBoundary()
    {
        var range = circleCollider.radius;

        for (int i = 0; i < pointNum; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / pointNum);
            points[i] = new Vector3(range * Mathf.Cos(rad), range * Mathf.Sin(rad), -1);
        }

        lineRenderer.SetPositions(points);
    }
}
