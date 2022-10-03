using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var v = new Vector2(0, 0);
        var t = new Vector2(5, 0);
        if(Vector2.Dot(t-v, new Vector2(0, -1)) < 1e-2){
            Debug.Log("HI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
