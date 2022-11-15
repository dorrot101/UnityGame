using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject[] Keys;
    int maxKeyNum = 3;

    // Start is called before the first frame update
    void Start()
    {
        InitializeKeys();
    }

    void InitializeKeys()
    {
        Keys = new GameObject[maxKeyNum];

        for(int i = 0; i<maxKeyNum; i++)
        {
           Keys[i] = transform.GetChild(i).gameObject;
        }
    }
}
