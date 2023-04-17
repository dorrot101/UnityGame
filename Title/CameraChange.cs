using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera first;
    public Camera second;
    public bool isfirst;
    // Start is called before the first frame update
    void ShowFirst()
    {
        first.enabled = true;
        second.enabled = false;
    }
    void ShowSecond()
    {
        first.enabled = false;
        second.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(isfirst == true)
        {
            ShowFirst();
        }
        else
        {
            ShowSecond();
        }
    }
}
