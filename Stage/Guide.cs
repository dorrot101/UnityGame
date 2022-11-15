using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject pressC;
    RotateObject rotateObject;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        rotateObject = GameObject.Find("Playable_planet").GetComponent<RotateObject>();
        cam = Camera.main;
        pressC.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rotateObject.isRotate)
        {
            pressC.SetActive(true);
            var height = cam.ScreenToWorldPoint(Input.mousePosition).y;
            var width = cam.ScreenToWorldPoint(Input.mousePosition).x;
            pressC.transform.position = new Vector3(width, height, 0);
        }
        else pressC.SetActive(false);
    }
}
