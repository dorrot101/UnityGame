using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endpoint : MonoBehaviour
{
    public GameObject dialogBox;

    TextMeshProUGUI textmeshpro;
    StageManager stageManager;

    bool isPaused = false;
    bool isEnable = false;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();

        textmeshpro = dialogBox.GetComponent<TextMeshProUGUI>();

        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused && Input.anyKeyDown)
        {
            var nextStage = stageManager.GetNextStage();

            if (nextStage.Equals("end"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Title");
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(nextStage);
            }
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
