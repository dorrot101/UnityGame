using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloablBPM : MonoBehaviour
{
    int bpm;
    public int globalBpm { get { return bpm; } private set {; }}
    // Start is called before the first frame update
    void Start()
    {
        bpm = 120;
    }

    void Sync()
    {

    }
}
