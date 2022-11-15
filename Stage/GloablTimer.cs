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
    const float defaultPlaytime = 20.0f;
    bool isEnd = false;

    public float TimeToLive { get {return timetolive; } set { timetolive = value; } }

    // Start is called before the first frame update
    void Start()
    {
        rotateobject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();

        stagemanager = GameObject.Find("StageManager").GetComponent<StageManager>();
        
        textmeshpro = GetComponent<TextMeshProUGUI>();

        timetolive = defaultPlaytime;

        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateobject.isRotate)
        {
            timetolive -= Time.deltaTime;
        }
        else
        {
            timetolive -= 0.5f * Time.deltaTime;
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
