using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GloabalTimer: MonoBehaviour
{
    TextMeshProUGUI textmeshpro;
    RotateObject rotateobject;
    StageManager stagemanager;
    public GameObject endPanel;

    float timetolive;
    public bool isEnd = false;

    public float TimeToLive { get {return timetolive; } set { timetolive = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        rotateobject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();

        stagemanager = GameObject.Find("StageManager").GetComponent<StageManager>();
        
        textmeshpro = GetComponent<TextMeshProUGUI>();

        if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            timetolive = 60.0f;
        }
        else timetolive = 60.0f -  15.0f * (SceneManager.GetActiveScene().name[5]-'1');

        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateobject.isRotate)
        {
            timetolive -= 1.5f *Time.deltaTime;
        }
        else
        {
            timetolive -= Time.deltaTime;
        }

        textmeshpro.text = (Mathf.Round(timetolive * 10.0f) / 10.0f).ToString();

        if (timetolive < 0)
        {
            isEnd = true;
        }

        if (isEnd)
        {
            Time.timeScale = 0;
            endPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(stagemanager.GetCurrentStage());
            }
        }
    }
}
