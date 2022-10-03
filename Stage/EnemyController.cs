using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    float time = 0.0f;
    float velocity = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RotateObject ch = collision.collider.GetComponent<RotateObject>();

        if(ch != null)
        {
            Debug.Log(Time.time);
        }
    }

    void Move(float vel)
    {
        enemy.transform.position = (Vector2)enemy.transform.position + new Vector2(vel, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Move(velocity);

        if(time > 4.0f)
        {
            Destroy(enemy);
        }
    }
}
