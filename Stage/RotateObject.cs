using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateObject : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 directionVector;
    Vector3 rotateVector = new Vector3(0,0,-1);
    public GameObject center;
    GameObject dashBar;
    glbTimer timer;

    public float G = 10.0f;
    public float multiple = 20.0f;
    float range;
    float currentSpeed;
    float maxVelocity = 10.0f;

    float m1, m2, r;

    bool isrotate = true;
    bool isAccel = false;
    bool isSettling = false;
    bool isFixed = false;
    bool isSettled = true;
    bool islimited = true;
    public bool settled { get { return isSettled; } }
    public int charge { set { dashcount = maxDashcount; } }

    int dashcount;
    int maxDashcount = 3;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Timer
        GameObject.Find("GlobalTimer").GetComponent<glbTimer>().gametimer = 5.0f;

        //Initialize variables
        rigidbody2d = GetComponent<Rigidbody2D>();
        range = center.GetComponent<GravityObject>().GetRange();
        transform.position = (Vector2)center.transform.position + new Vector2(range, 0);
        
        InitialVelocity();
        dashcount = maxDashcount;
        dashBar = GameObject.Find("DashBar");
    }

    void Launch()
    {
        isrotate = false;
        isSettling = false;
        isFixed = true;
        isSettled = false;
    }

    private void FixedUpdate()
    {
        if (!isFixed)
        {
            directionVector = rigidbody2d.velocity.normalized;
        }
        LimitVelocity();
        Gravity();
        if (isAccel)
        { 
            Accelerate(multiple);
            isAccel = false;
        }
    }

    void LimitVelocity()
    {
        if (islimited && rigidbody2d.velocity.magnitude > maxVelocity) rigidbody2d.velocity = rigidbody2d.velocity.normalized * maxVelocity;
        islimited = false;
    }

    void InitialVelocity()
    {
        m2 = center.GetComponent<Rigidbody2D>().mass;
        r = Vector2.Distance(transform.position, center.transform.position);
        currentSpeed = Mathf.Sqrt((G * m2) / r);
        rigidbody2d.velocity = Vector2.up * currentSpeed;
    }

    void Gravity()
    {
        m1 = rigidbody2d.mass;
        m2 = center.GetComponent<Rigidbody2D>().mass;

        var accVector = (Vector2)(Vector3.Cross(directionVector, rotateVector).normalized);

        if (isrotate)
        {
            rigidbody2d.AddForce(accVector * (Mathf.Pow(rigidbody2d.velocity.magnitude, 2) / r));
        }
        else if(isrotate == false && isSettling == true)
        {
            center.GetComponent<CircleCollider2D>().enabled = false;

            if (Vector2.Dot(center.transform.position - transform.position, directionVector) < 1e-2)
            {
                Debug.Log("Gravity");
                center.GetComponent<CircleCollider2D>().radius = Vector2.Distance(center.transform.position, transform.position) / Mathf.Max(center.transform.localScale.x, center.transform.localScale.y);
                center.GetComponent<CircleCollider2D>().enabled = true;

                r = Vector2.Distance(transform.position, center.transform.position);
                rotateVector = Vector2.Dot(directionVector, new Vector2(center.transform.position.x, center.transform.position.y)) > 0 ? new Vector3(0, 0, 1) : new Vector3(0, 0, -1);
                rigidbody2d.velocity = directionVector * currentSpeed;
                
                isSettled = true;
                isrotate = true;
                isSettling = false;
                isFixed = false;
            }
        }
    }

    private void Update()
    {
        Debug.Log(rigidbody2d.velocity);
        if (Input.GetKeyDown(KeyCode.X))
        {
            isrotate = false;
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isrotate == false) isAccel = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }
    }

    public void Accelerate(float multiple)
    {
        if(dashcount > 0)
        {
            dashcount--;
            rigidbody2d.AddForce(directionVector * multiple);
            Debug.Log("Current Energy is " + dashcount + "/" + maxDashcount);
        }
        else
        {
            Debug.Log("Energy is low");
        }
    }

    public void SetVelocity(float multiple)
    {
        rigidbody2d.velocity = multiple * rigidbody2d.velocity;
    }

    public void Settle(GameObject center)
    {
        Debug.Log("??");
        if (isSettled == false)
        {
            this.center = center;
            rigidbody2d.velocity = directionVector * currentSpeed;
            isSettling = true;
        }
    }

}
