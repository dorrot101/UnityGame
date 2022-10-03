using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glbTimer : MonoBehaviour
{
    public float gametimer = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gametimer -= Time.deltaTime;
        gametimer = Mathf.Round(gametimer * 100) * 0.01f;

        if (gametimer < 0)
        {
            Debug.Log("End");
        }
    }
}
