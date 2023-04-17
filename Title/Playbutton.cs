using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playbutton : MonoBehaviour
{
    public Button thisbutton;
    // Start is called before the first frame update
    void Start()
    {
        thisbutton = GetComponent<Button>();
        thisbutton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button");
        SceneManager.LoadScene("Stage1");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
