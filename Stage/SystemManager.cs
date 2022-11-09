using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    SpriteRenderer backGround;
    RotateObject rotateObject;
    StageManager stagemanager;

    public GameObject boundaryOutPanel;

    float screenHeight;
    float screenWidth;

    float boundaryXpos;
    float boundaryYpos;

    public float getScreenHeight { get { return screenHeight; } }
    public float getScreenWidth { get { return screenWidth; } }

    private void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        
        backGround = GameObject.Find("Space Background").GetComponent<SpriteRenderer>();

        rotateObject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();

        stagemanager = GameObject.Find("StageManager").GetComponent<StageManager>();

        boundaryXpos = backGround.bounds.size.x;
        boundaryYpos = backGround.bounds.size.y;
    }

    private void Update()
    {
        if (isOutOfBoundary())
        {
            Restart();
        }
    }

    private bool isOutOfBoundary()
    {
        var playerXpos = rotateObject.transform.position.x;
        var playerYpos = rotateObject.transform.position.y;
        return playerXpos > boundaryXpos/2 || playerXpos < -boundaryXpos/2 || playerYpos > boundaryYpos/2 || playerYpos < -boundaryYpos/2;
    }

    void Restart()
    {
        Time.timeScale = 0;
        boundaryOutPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(stagemanager.getCurrentStage);
        }
    }

}
