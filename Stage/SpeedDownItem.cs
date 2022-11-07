using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            rotateObject.SetCurrentVelocity(0.75f);
        }

        Destroy(gameObject);
    }
}
