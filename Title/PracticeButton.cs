using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeButton : MonoBehaviour
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
        SceneManager.LoadScene("Tutorial");
    }
}
