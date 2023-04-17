using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    float parameter;

    void Awake()
    {
        parameter = 1.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            rotateObject.SetCurrentVelocity(parameter);
        }

        Destroy(gameObject);
    }
}
