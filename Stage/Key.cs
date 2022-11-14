using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{    
    float parameter;
    TimeoutPanel timeoutpanel;

    void Awake()
    {
        parameter = 0.75f;
        timeoutpanel = GameObject.Find("TimerText").GetComponent<TimeoutPanel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            timeoutpanel.TimeToLive += 10.0f;
            gameObject.SetActive(false);
        }

    }
}
