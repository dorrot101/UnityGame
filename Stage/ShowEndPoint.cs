using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEndPoint : MonoBehaviour
{
    public RotateObject rotateobject;
    public Endpoint endpoint;

    float frequency = 5;
    float radius = 2.0f;
    float deg;
    float lapsedTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowOuter();
    }

    void ShowOuter()
    {
        var temp = (endpoint.transform.position - rotateobject.transform.position).normalized;
        transform.localPosition = temp * radius;
    }
}
