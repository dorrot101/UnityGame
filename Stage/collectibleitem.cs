using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleitem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("why");
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            rotateObject.SetVelocity(2.0f);
        }

        Destroy(gameObject);
    }
}
