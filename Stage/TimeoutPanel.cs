using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TimeoutPanel: MonoBehaviour
{
    TextMeshProUGUI textmeshpro;
    RotateObject rotateobject;
    public GameObject endPanel;

    float timetolive;
    const float defaultPlaytime = 20.0f;
    bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        rotateobject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();
        textmeshpro = GetComponent<TextMeshProUGUI>();

        timetolive = defaultPlaytime;

        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateobject.isRotate)
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
                SceneManager.LoadScene("Stage1");
            }
        }
    }
}
