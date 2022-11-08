using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHitLine : MonoBehaviour
{
    BoxCollider2D boxCollider2d;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody2d;

    Vector3 direction;
    float speed = 2.0f;


    // Start is called before the first frame update
    void Awake()
    {
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovingLoop();
    }

    private void MovingLoop()
    {
        transform.position += speed * Time.deltaTime * direction;
        if (transform.position.x > 3.0f || transform.position.x < 0.0f)
        {
            direction *= -1;
        }
    }
}
