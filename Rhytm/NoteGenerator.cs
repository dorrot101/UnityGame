using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    float respwanTime = 0.0f;

    bool ishit = false;
    public GameObject bnote;
    Note tnote;

    private void Awake()
    {

    }

    private void Update()
    {
        respawn();


    }

    void respawn()
    {
        respwanTime += Time.deltaTime;

        if (respwanTime > 1.0f)
        {
            GameObject instant = Instantiate(bnote, new Vector2(-2, 2), Quaternion.identity);
            tnote = instant.GetComponent<Note>();
            respwanTime = 0.0f;
        }


    }

}
