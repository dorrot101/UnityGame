using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class StageManager : MonoBehaviour
{
    string currentStage;
    int StageNo;

    enum Stage
    {
        Stage1,
        Stage2,
        Stage3
    }

    // Start is called before the first frame update
    void Awake()
    {
        currentStage = SceneManager.GetActiveScene().name;
        StageNo = currentStage[5] - '0';
        Debug.Log(StageNo);
    }

    public string getNextScene()
    {
        var nextStage = "Stage" + (StageNo + 1);
        return StageNo < 3 ? nextStage : currentStage;
    }

    public float getMaxVelocity() 
    {
        var velocity = 10.0f * StageNo;
        Debug.Log(velocity);
        return velocity;
    }

}
