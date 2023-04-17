using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCPanel : MonoBehaviour
{
    Button continueButton;
    Button RestartButton;
    Button quitButton;

    StageManager stageManager;

    private void Start()
    {
        continueButton = transform.GetChild(0).GetComponent<Button>();
        RestartButton = transform.GetChild(1).GetComponent<Button>();
        quitButton = transform.GetChild(2).GetComponent<Button>();

        continueButton.onClick.AddListener(Continue);
        RestartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(Quit);

        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
    }

    void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    void Restart()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.LoadScene(stageManager.GetCurrentStage());
    }

    void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
