using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    BoxCollider boxcollider;
    Rigidbody2D rigidbody2D;
    AudioSource audiosource;

    float counter;
    float awakeTime;
    void Awake()
    {
        boxcollider = GetComponent<BoxCollider>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        audiosource = gameObject.GetComponent<AudioSource>();

        awakeTime = Time.time;
    }

    public void MakeHit()
    {
        var xpos = UnityEngine.Random.Range(-5, 5);
        var ypos = UnityEngine.Random.Range(-5, 5);
        transform.position = new Vector3(xpos, ypos, 0);
        audiosource.Play();
    }

    private void Update()
    {
        if (Time.time - awakeTime > 0.5f) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {

            Destroy(gameObject);
        }
    }
}
