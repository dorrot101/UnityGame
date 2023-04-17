using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleitem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            rotateObject.SetCurrentVelocity(2.0f);
        }

        Destroy(gameObject);
    }
}
