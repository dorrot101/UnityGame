using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject[] keys;
    int maxKeyNum = 3;

    // Start is called before the first frame update
    void Start()
    {
        InitializeKeys();
    }

    void InitializeKeys()
    {
        keys = new GameObject[maxKeyNum];

        for(int i = 0; i<maxKeyNum; i++)
        {
           keys[i] = transform.GetChild(i).gameObject;
        }
    }
}
