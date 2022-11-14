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
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 2.0f;

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

        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.angularVelocity = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if (rotateObject != null && rotateObject.isRotate == false)
        {
            rotateObject.Settle(this);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    RotateObject rotateObject = collision.collider.GetComponent<RotateObject>();
        
    //    if(rotateObject != null && rotateObject.settled == false)
    //    {
    //        Debug.Log("Planet is settled and energy is charged");
    //        rotateObject.charge = 3;
    //        rotateObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    //        rotateObject.Settle(this.GetComponent<GravityObject>());
    //    }
    //}

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
