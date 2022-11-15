using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject pressC;
    public GameObject dashCountGuide;
    public GameObject TimeoutGuide;

    RotateObject rotateObject;
    GloabalTimer GloabalTimer;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rotateObject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();
        GloabalTimer = GameObject.Find("TimerText").GetComponent<GloabalTimer>();
        cam = Camera.main;
        pressC.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rotateObject.isRotate)
        {
            FollowMouseCursor();
        }
        else if(rotateObject.DashCount == 0)
        {
            pressC.SetActive(false);
            DashCountGuide();
        }

        if(GloabalTimer.isEnd)
        {
            TimeoutGuide();
        }
        
    }

    void FollowMouseCursor(){
        pressC.SetActive(true);
        var height = cam.ScreenToWorldPoint(Input.mousePosition).y;
        var width = cam.ScreenToWorldPoint(Input.mousePosition).x;
        pressC.transform.position = new Vector3(width, height, 0);
    }

    void DashCountGuide()
    {
        Time.timeScale = 0;
        dashCountGuide.SetActive(true);
        if(Input.anyKeyDown())
        {
            Time.timeScale = 1;
            dashCountGuide.SetActive(false);
            rotateObject.DashCount = 3;
        }
    }

    void TimeoutGuide(){
        Time.timeScale = 0;        
        dashCountGuide.SetActive(true);
        if(Input.anyKeyDown())
        {
            Time.timeScale = 1;
            dashCountGuide.SetActive(false);
            GloabalTimer.TimeToLive = 20.0f;
        }
    }
}
