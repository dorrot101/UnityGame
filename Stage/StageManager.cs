using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class StageManager : MonoBehaviour
{
    string currentStage;
    int StageNo;
    int finalStage;

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
        currentStage = SceneManager.GetActiveScene().name;
        StageNo = currentStage[5] - '0';
        finalStage = (int)Stage.End;
    }

    public int getCurrentStage(){
        return stageNo;
    }

    public string getNextStage()
    {
        var nextStage = "Stage" + (StageNo + 1);

        return StageNo < finalStage ? nextStage : "end";
    }

    public float getMaxVelocity() 
    {
        var velocity = 10.0f * StageNo;
        return velocity;
    }

}
