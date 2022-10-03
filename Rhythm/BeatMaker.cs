using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMaker : MonoBehaviour
{
    bool ishit = false;
    public bool gethit { get { return ishit; } }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ishit = true;
            Debug.Log("hit?");
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            ishit = false;
        }
    }
}
