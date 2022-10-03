using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        move();
    }

    void move()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        BeatMaker note = collision.gameObject.GetComponent<BeatMaker>();
        if (note != null && note.gethit)
        {
            audioSource.Play();
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
