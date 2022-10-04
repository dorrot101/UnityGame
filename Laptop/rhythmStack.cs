using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmStack : MonoBehaviour
{
    int[] stack;
    int currentPointer;
    int beatsNum;

    float timer;

    bool ispressed = false;


    void InitializeStack()
    {
        for(int i = 0; i<stack.Length; i++)
        {
            stack[i] = UnityEngine.Random.Range(1,4);
        }
    }

    bool Reverse(bool status)
    {
        return !status;
    }

    // Start is called before the first frame update
    void Start()
    {
        beatsNum = 8;
        stack = new int[beatsNum];
        timer = 0.0f;

        InitializeStack();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.5f){
            currentPointer++;
            ispressed = Reverse(ispressed);
            timer = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.X) && !ispressed)
        {
            stack[currentPointer] -= 1;
            ispressed = Reverse(ispressed);
        }

        
    }


}
