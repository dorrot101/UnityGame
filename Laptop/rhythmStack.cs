using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmStack : MonoBehaviour
{
    int[] stack;
    int currentPointer;
    int beatsNum;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        beatsNum = 8;
        stack = new int[beatsNum];
        timer = 0.0f;

        InitializeStack();

    }

    void InitializeStack()
    {
        for(int i = 0; i<stack.Length; i++)
        {
            stack[i] = UnityEngine.Random.Range(1,4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.5f){
            currentPointer++;
            timer = 0.0f;
        }
    }
}
