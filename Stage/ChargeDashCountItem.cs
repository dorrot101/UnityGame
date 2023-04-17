using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDashCountItem : MonoBehaviour
{
    float parameter;

    void Awake()
    {
        // parameter = 1.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            rotateObject.DashCount = rotateObject.MaxDashCount;
        }

        Destroy(gameObject);
    }
}
