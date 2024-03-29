using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDashCountUp : MonoBehaviour
{
    int parameter;

    void Awake()
    {
        parameter = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            rotateObject.MaxDashCount += parameter;
        }

        Destroy(gameObject);
    }
}
