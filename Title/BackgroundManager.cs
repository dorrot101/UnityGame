using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundManager : MonoBehaviour
{
    public float horizontalSpeed = 0.2f;
    public float verticalSpeed = 1f;
    SpriteRenderer backGround;
    Camera cam;

    float boundaryXpos;
    float boundaryYpos;

    Vector2 camInWorldSize;

    float upSpeed;

    Vector2 directionVector;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);

        backGround = GetComponent<SpriteRenderer>();

        boundaryXpos = backGround.bounds.size.x;
        boundaryYpos = backGround.bounds.size.y;

        cam = Camera.main;

        //cam.transform.position = new Vector3(-boundaryXpos / 2 + cam.pixelHeight / 2, boundaryYpos / 2 - cam.pixelWidth / 2, 0);

        camInWorldSize.x = Mathf.Abs(((Vector2)cam.ViewportToWorldPoint(cam.transform.position)).x);
        camInWorldSize.y = Mathf.Abs(((Vector2)cam.ViewportToWorldPoint(cam.transform.position)).y);

        cam.transform.position = new Vector3(-boundaryXpos / 2 - camInWorldSize.x, boundaryYpos / 2 + camInWorldSize.y, -10);

        directionVector = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        //var time = Time.deltaTime;
        //upSpeed += time * verticalSpeed;

        cam.transform.position = new Vector3(0, upSpeed, -10);

        //cam.transform.position = new Vector3(upSpeed * directionVector.x, upSpeed * directionVector.y, -10);


        //if (isOutOfBoundary()) 
        //{
        //    var temp = Vector2.zero;
        //    var upper = new Vector2(0, -1);
        //    var down = new Vector2(1, 0);
        //    temp.x = upper.x * directionVector.x + upper.y * directionVector.y;
        //    temp.y = down.x * directionVector.x + down.y * directionVector.y;
        //    directionVector = temp;
        //}
    }

    bool isOutOfBoundary()
    {
        var result = false;
        if
        (
            -boundaryXpos / 2 >= cam.transform.position.x - camInWorldSize.x ||
            boundaryXpos / 2 <= cam.transform.position.x + camInWorldSize.x ||
            -boundaryYpos >= cam.transform.position.y - camInWorldSize.y ||
            boundaryYpos <= cam.transform.position.y + camInWorldSize.y
        ) result = true;

        return result;
    }
}
