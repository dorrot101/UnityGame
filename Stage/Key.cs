using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{    
    float parameter;
    GloabalTimer GloabalTimer;

    void Awake()
    {
        parameter = 5.0f;
        GloabalTimer = GameObject.Find("TimerText").GetComponent<GloabalTimer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            GloabalTimer.TimeToLive += parameter;
            gameObject.SetActive(false);
        }

    }
}
