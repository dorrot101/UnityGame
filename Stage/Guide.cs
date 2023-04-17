using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject instructionPanel;
    public GameObject pressC;
    public GameObject dashCountGuide;
    public GameObject timeoutGuide;

    RotateObject rotateObject;
    GloabalTimer GloabalTimer;
    Camera cam;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        rotateObject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();
        GloabalTimer = GameObject.Find("TimerText").GetComponent<GloabalTimer>();
        cam = Camera.main;
        //pressC.SetActive(false);
        //dashCountGuide.SetActive(false);
        //timeoutGuide.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rotateObject.isRotate)
        {
            FollowMouseCursor();
        }
        else pressC.SetActive(false);

        if (rotateObject.DashCount == 0 && !isPaused)
        {

            rotateObject.DashCount = 3;
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
        dashCountGuide.SetActive(true);
        if (Input.anyKeyDown)
        {
            dashCountGuide.SetActive(false);
        }
    }

    void TimeoutGuide(){
        timeoutGuide.SetActive(true);
        if(Input.anyKeyDown)
        {
            timeoutGuide.SetActive(false);
            GloabalTimer.TimeToLive = 20.0f;
        }
    }
}
