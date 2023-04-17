using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyGenerator : MonoBehaviour
{
    StageManager stageManager;
    GameObject currentKey;
    SystemManager systemManager;
    Endpoint endpoint;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    GameObject[] Keys;
    public GameObject[] KeyLists;


    int maxKeyNum = 3;
    int currentKeyNum = 1;
    float territory = 250.0f;

    public bool getall = false;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        systemManager = GameObject.Find("SystemManager").GetComponent<SystemManager>();
        endpoint = GameObject.Find("Endpoint").GetComponent<Endpoint>();


        if (SceneManager.GetActiveScene().name.Equals("Tutorial")) territory = 50.0f;
        InitializeKeys();
        endpoint.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentKeyNum < maxKeyNum && KeyLists[currentKeyNum - 1].activeInHierarchy == false)
        {
            KeyLists[currentKeyNum++].SetActive(true);
        }
        
        if (GetAll())
        {
            endpoint.gameObject.SetActive(true);
        }

        //Debug.Log(getall);
    }

    void InitializeKeys()
    {
        Keys = new GameObject[maxKeyNum];
        KeyLists = new GameObject[maxKeyNum];

        Keys[0] = key1;
        Keys[1] = key2;
        Keys[2] = key3;

        for(int i = 0; i<maxKeyNum; i++)
        {
            var xpos = UnityEngine.Random.Range(-territory / 2, territory / 2);
            var ypos = UnityEngine.Random.Range(-territory / 2, territory / 2);

            KeyLists[i] = Instantiate(Keys[i], new Vector2(xpos, ypos), Quaternion.identity);
            KeyLists[i].SetActive(false);
        }

        KeyLists[0].SetActive(true);
    }

    bool GetAll()
    {
        bool result = true;

        for (int i = 0; i < maxKeyNum; i++)
        {
            result &= !KeyLists[i].activeInHierarchy;
        }

        return result;
    }
}
