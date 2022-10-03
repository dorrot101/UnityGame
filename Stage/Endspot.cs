using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endspot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RotateObject rotateObject = collision.gameObject.GetComponent<RotateObject>();  
        if(rotateObject != null)
        {
            Debug.Log("End");
            
        }
    }

}
