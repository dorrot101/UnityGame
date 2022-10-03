using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Recoder : MonoBehaviour
{
    float[][] rhythmList;
    float[] recoder;

    int maxBeat = 8;
    int iter = 0;
    int currentRhythm;

    bool isShown = false;
    bool isRecoding = false;
    bool isPlaying = false;

    KeyCode[] numericKeys =
    {
        KeyCode.Alpha0,
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9
    };

    public GameObject hitBoxController;

    void InitializeList()
    {
        rhythmList = new float[numericKeys.Length][];
        recoder = new float[maxBeat];

        for (int i = 0; i < rhythmList.Length; i++)
        {
            rhythmList[i] = recoder;
        }
    }

    void GetNumericKey()
    {
        for (int i = 0; i < numericKeys.Length; i++)
        {
            if (Input.GetKeyDown(numericKeys[i]) && !isRecoding)
            {
                currentRhythm = i;
                for (int j = 0; j < rhythmList[currentRhythm].Length; j++)
                {
                    Debug.Log(rhythmList[currentRhythm][j]);
                }
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRhythm = 0;
        InitializeList();
    }
    void Attack()
    {
        GameObject hitBox = Instantiate(hitBoxController, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        HitBoxController hitbox = hitBox.GetComponent<HitBoxController>();
        hitbox.MakeHit();
    }

    // Update is called once per frame
    void Update()
    {
        GetNumericKey();

        if (Input.anyKeyDown)
        {
            Attack();
 
            if (iter != maxBeat)
            {
                isRecoding = true;
                rhythmList[currentRhythm][iter] = Time.time;
                Debug.Log((iter + 1) + "/" + maxBeat);
                iter++;
            }
            else
            {
                isRecoding = false;
                iter = 0;
            }
        }

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    if(iter != maxBeat)
        //    {
        //        recoder[iter++] = Time.time;
        //        Debug.Log((iter + 1) / maxBeat);
        //    }
        //}

        //if(iter == recoder.Length && isShown == false)
        //{
        //    for (int i = 0; i < maxBeat; i++)
        //    {
        //        if(i > 0)
        //        Debug.Log(recoder[i] - recoder[i-1]);
        //    }
        //    isShown = true;
        //}

        //if (Input.GetKeyDown(KeyCode.Z) && !isPlaying)
        //{
        //    isPlaying = !isPlaying;

        //}
    }


    private void FixedUpdate()
    {
        
    }
}
