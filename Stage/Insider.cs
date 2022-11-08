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

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        circleCollider = GetComponent<CircleCollider2D>();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 360;

        ShowBoundary();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowBoundary();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateobject = collision.gameObject.GetComponent<RotateObject>();
        if(rotateobject != null && !rotateobject.isRotate)
        {
            rotateobject.SetCurrentVelocity(-1);
        }
    }

    private void ShowBoundary()
    {
        pointNum = 360;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        points = new Vector3[pointNum];
        var range = circleCollider.radius;

        for (int i = 0; i < pointNum; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / pointNum);
            points[i] = new Vector3(range * Mathf.Cos(rad), range * Mathf.Sin(rad), -1);
        }
        lineRenderer.material.color = Color.red;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.SetPositions(points);
    }
}