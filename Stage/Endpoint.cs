using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endpoint : MonoBehaviour
{
    public GameObject dialogBox;
    StageManager stageManager;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();

        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused && Input.anyKeyDown)
        {
            Time.timeScale = 1;

            var nextStage = stageManager.getNextScene();

            SceneManager.LoadScene(nextStage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();

        if(rotateObject != null)
        {
            DisplayDialog();
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void DisplayDialog()
    {
        dialogBox.SetActive(true);
    }
}
