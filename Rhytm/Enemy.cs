using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GloablBPM bpmController;
    AudioSource audiosourse;
    PlayableCharacter character;

    float time = 0.0f;
    float intervalPerBeat;
    float frequency;
    const float minute = 60.0f;

    public int notePerBeat = 4;
    public int beatsPerMeasure = 4;
    int bpm;

    // Start is called before the first frame update
    void Start()
    {
        bpmController = GameObject.Find("GlobalAudio").GetComponent<GloablBPM>();
        character = GameObject.Find("Character").GetComponent<PlayableCharacter>();
        audiosourse = gameObject.GetComponent<AudioSource>();

        intervalPerBeat = minute / bpm;
        frequency = bpm / minute;
        bpm = bpmController.globalBpm;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        intervalPerBeat = minute / bpm;
        //Attack();
        Move();
    }

    void Attack()
    {
        if (time > intervalPerBeat)
        {
            //audiosourse.Play();
            time -= intervalPerBeat;
        }
        Destroy(gameObject);
    }

    void Move()
    {
        var direction = character.transform.position - transform.position;
        transform.position += direction.normalized * 0.25f * Time.deltaTime;
    }
}
