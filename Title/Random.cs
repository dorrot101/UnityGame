using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Random : MonoBehaviour
{
    public GameObject player;
    public GameObject mob;

    Hashtable rdtable = new Hashtable();

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rdtable.Add(60.0f, "player");
        rdtable.Add(100.0f, "mob");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(hi(1));
    }

    IEnumerator hi(float delayTime)
    {
        //Debug.Log("Time : " + Time.time);
        yield return new WaitForSeconds(delayTime);
    }
}
