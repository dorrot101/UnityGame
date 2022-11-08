using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelTheBeat : MonoBehaviour
{
    float time;
    float freq;
    float maxheight;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        freq = 0.5f;
        maxheight = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        var inc = (maxheight - 1.0f) / (freq / 2);
        var x = time % freq;
        var y = (freq / 2) - x >= 0 ? inc * x : (-inc * x + maxheight); 

        transform.localScale = new Vector2(1.0f, 1.0f + y);
    }
}
