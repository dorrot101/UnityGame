using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class StageManager : MonoBehaviour
{
    string currentStage;
    int stageNo;
    int finalStage;
    float maxVelocity = 30.0f;

    public int StageNo { get { return stageNo; } }

    //Set of stages
    enum Stage
    {
        Stage1,
        Stage2,
        Stage3,
        End
    }

    // Start is called before the first frame update
    void Awake()
    {
        //Get name of current scene
        currentStage = SceneManager.GetActiveScene().name;
        //Extract number of current scene
        stageNo = currentStage[5] - '0';
        //Get number of final stage
        finalStage = (int)Stage.End;
    }
    public string GetCurrentStage()
    {
        return currentStage;
    }

    public string GetNextStage()
    {
        var nextStage = "Stage" + (StageNo + 1);

        return StageNo < finalStage ? nextStage : "End";
    }

    public float GetMaxVelocity() 
    {
        var velocity = 20.0f + 0.5f * (StageNo-1);
        if (SceneManager.GetActiveScene().name.Equals("Tutorial")) velocity = 10.0f;

        return velocity;
    }

    public float GetTimer()
    {
        return 60 /StageNo;
    }

}
