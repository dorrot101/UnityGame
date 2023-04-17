using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimerItem : MonoBehaviour
{
    float parameter;

    void Awake()
    {
        parameter = 0.75f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if (rotateObject != null)
        {
            rotateObject.SetCurrentVelocity(parameter);
        }

        Destroy(gameObject);
    }
}
