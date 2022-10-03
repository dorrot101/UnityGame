using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    GameObject gravityObject;
    CircleCollider2D circleCollider;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody2d;

    int pointNum;
    Vector3[] points;
    float range = 10.0f;

    // Start is called before the first frame update
    void Awake()
    {
        gravityObject = GameObject.Find(this.name);

        lineRenderer = gravityObject.AddComponent<LineRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        lineRenderer.positionCount = 360;

        circleCollider = gravityObject.GetComponent<CircleCollider2D>();
        circleCollider.radius = 2.0f;

        ShowBoundary();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2d.angularVelocity = 0.0f;
        RotateObject rotateObject = collision.collider.GetComponent<RotateObject>();
        
        if(rotateObject != null && rotateObject.settled == false)
        {
            Debug.Log("Planet is settled and energy is charged");
            rotateObject.charge = 3;
            rotateObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
            rotateObject.Settle(gravityObject);
        }
    }

    public float GetRange()
    {
        return range;
    }

    private void FixedUpdate()
    {
        ShowBoundary();
    }

    private void ShowBoundary()
    {
        pointNum = 360;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        points = new Vector3[pointNum];
        var range = circleCollider.radius;

        for (int i = 0; i< pointNum; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / pointNum) ;
            points[i] = new Vector3(range * Mathf.Cos(rad) , range * Mathf.Sin(rad), -1);
        }
        lineRenderer.material.color = Color.white;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.SetPositions(points);
    }
}
