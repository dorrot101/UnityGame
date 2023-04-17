using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    CircleCollider2D circleCollider;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody2d;

    Vector3[] points;
    int pointNum;

    float range = 10.0f;
    public float getRange { get { return range; } }

    const float minRange = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        InitializeCircleCollider(2.0f);
        InitializeLineRenderer();
        InitializeRigidbody2D();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if (rotateObject != null && rotateObject.isRotate == false)
        {
            rotateObject.Settle(this);
        }
    }

    void InitializeCircleCollider(float parameter)
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = parameter;
    }

    void InitializeLineRenderer()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 360;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.material.color = Color.white;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        pointNum = lineRenderer.positionCount;
        points = new Vector3[pointNum];
    }

    void InitializeRigidbody2D()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.angularVelocity = 0.0f;
    }

    private void FixedUpdate()
    {
        ShowBoundary();
    }

    private void ShowBoundary()
    {
        var range = circleCollider.radius;

        for (int i = 0; i<pointNum ; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / pointNum) ;
            points[i] = new Vector3(range * Mathf.Cos(rad) , range * Mathf.Sin(rad), -1);
        }


        lineRenderer.SetPositions(points);
    }
}
