using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    float camHeight;
    float camWidth;

    float boundaryXpos;
    float boundaryYpos;
 
    SpriteRenderer backGround;
    RotateObject rotateObject;

    public GameObject boundaryOutPanel;

    public float getCamHeight { get { return camHeight; } }
    public float getCamWidth { get { return camWidth; } }

    private void Start()
    {
        camHeight = Screen.height;
        camWidth = Screen.width;
        backGround = GameObject.Find("Space Background").GetComponent<SpriteRenderer>();

        rotateObject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();

        boundaryXpos = backGround.bounds.size.x;
        boundaryYpos = backGround.bounds.size.y;
    }

    private void Update()
    {
        var playerXpos = rotateObject.transform.position.x;
        var playerYpos = rotateObject.transform.position.y;
        if (playerXpos > boundaryXpos/2 || playerXpos < -boundaryXpos/2 || playerYpos > boundaryYpos/2 || playerYpos < -boundaryYpos/2)
        {
            Time.timeScale = 0;
            boundaryOutPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Stage1");
            }
        }
    }

}
