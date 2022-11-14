using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RotateObject : MonoBehaviour
{
    enum State
    {
        isRotate,
        isAccel,
        isSettling,
        isSettled,
        isFixed,
        isBound
    }

    enum Scene
    {
        Stage1,
        Stage2,
        Stage3
    }

    Rigidbody2D rigidbody2d;
    GameObject dashBar;
    StageManager stageManager;

    Vector2 directionVector;
    Vector3 rotateVector = new Vector3(0,0,-1);
    GravityObject center;

    bool[] condition;

    float range;
    float currentSpeed;
    float maxVelocity;

    float m1, m2, r;
    public float G = 10.0f;
    public float multiple = 20.0f;

    int dashcount;
    int maxDashcount = 3;

    public bool isRotate    { get { return condition[(int)State.isRotate]; }    set { condition[(int)State.isRotate] = value; } }
    public bool isAccel     { get { return condition[(int)State.isAccel]; }     set { condition[(int)State.isAccel] = value; } }
    public bool isSettling  { get { return condition[(int)State.isSettling]; }  set { condition[(int)State.isSettling] = value; } }
    public bool isSettled   { get { return condition[(int)State.isSettled]; }   set { condition[(int)State.isSettled] = value; } }
    public bool isFixed     { get { return condition[(int)State.isFixed]; }     set { condition[(int)State.isFixed] = value; } }
    public bool isBound     { get { return condition[(int)State.isBound]; }     set { condition[(int)State.isBound] = value; } }
    public int MaxDashCount { get { return maxDashcount; }  set {maxDashcount = value;}}
    public int DashCount    { get { return dashcount; }     set { dashcount = value; } }

    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.Find("Center").GetComponent<GravityObject>();

        //Initialize variables
        rigidbody2d = GetComponent<Rigidbody2D>();
        range = center.GetComponent<GravityObject>().getRange;
        transform.position = (Vector2)center.transform.position + new Vector2(range, 0);

        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();

        dashcount = maxDashcount;
        dashBar = GameObject.Find("DashBar");

        InitialVelocity();
        InitialCondition();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isRotate) SetCondition(State.isAccel, true);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
        }
    }


    private void FixedUpdate()
    {
        directionVector = rigidbody2d.velocity.normalized;
        currentSpeed = rigidbody2d.velocity.magnitude;

        Gravity();
        LimitVelocity();

        if (isAccel)
        { 
            Accelerate(multiple);
            SetCondition(State.isAccel, false);
        }
    }

    void InitialCondition()
    {
        condition = new bool[] { true, false, false, true, true, false };
    }

    void SetCondition(State state, bool change)
    {
        condition[(int)state] = change;
    }

    void Launch()
    {
        SetCondition(State.isRotate, false);
        SetCondition(State.isSettling, false);
        SetCondition(State.isFixed, false);
        SetCondition(State.isSettled, false);
    }

    void InitialVelocity()
    {
        directionVector = Vector2.up;

        m2 = center.GetComponent<Rigidbody2D>().mass;
        r = Vector2.Distance(transform.position, center.transform.position);
        currentSpeed = Mathf.Sqrt((G * m2) / r);

        rigidbody2d.velocity = currentSpeed * directionVector;

        maxVelocity = 10.0f;
        Debug.Log(maxVelocity);
    }
    void LimitVelocity()
    {
        if (isFixed && rigidbody2d.velocity.magnitude > maxVelocity) rigidbody2d.velocity = rigidbody2d.velocity.normalized * maxVelocity;
    }

    void Gravity()
    {

        m2 = center.GetComponent<Rigidbody2D>().mass;

        if (isRotate)
        {
            var accVector = (Vector2)(center.transform.position - transform.position).normalized;
            rigidbody2d.AddForce(currentSpeed * directionVector + accVector * (Mathf.Pow(rigidbody2d.velocity.magnitude, 2) / r));
        }
        else if(!isRotate && isSettling)
        {
            if (Mathf.Abs(Vector2.Dot(center.transform.position - transform.position, directionVector)) < 0.5)
            {
                center.GetComponent<CircleCollider2D>().radius = Vector2.Distance(center.transform.position, transform.position) / Mathf.Max(center.transform.localScale.x, center.transform.localScale.y); 
                r = Vector2.Distance(transform.position, center.transform.position);
                
                SetCondition(State.isRotate, true);
                SetCondition(State.isSettling, false);
                SetCondition(State.isFixed, true);
                SetCondition(State.isSettled, true);
            }
        }
        else if (isBound)
        {
            Debug.Log("Bound");
            var colliderRadius = center.GetComponent<CircleCollider2D>().radius * center.transform.localScale.x;
            var distance = Vector2.Distance(center.transform.position, transform.position);
            if (colliderRadius <= distance)
            {
                SetCondition(State.isSettling, true);
                SetCondition(State.isBound, false);
            }
        }

    }

    public void Collide()
    {
        SetCondition(State.isSettling, false);
        SetCondition(State.isBound, true);
        SetCurrentVelocity(-1);
    }

    void Accelerate(float multiple)
    {
        if(dashcount > 0)
        {
            dashcount--;
            
            Vector2 AccelVector = ((Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2)).normalized;
            currentSpeed = rigidbody2d.velocity.magnitude;
            rigidbody2d.velocity = AccelVector * currentSpeed;

            Debug.Log("Current Energy is " + dashcount + "/" + maxDashcount);
        }
        else
        {
            Debug.Log("Energy is low");
        }
    }

    public void SetCurrentVelocity(float multiple)
    {
        rigidbody2d.velocity = multiple * rigidbody2d.velocity;
    }

    public void Settle(GravityObject center)
    {
        if (!isSettled)
        {
            DashCount = MaxDashCount;

            this.center = center;
            SetCondition(State.isSettling, true);
        }
    }
}
