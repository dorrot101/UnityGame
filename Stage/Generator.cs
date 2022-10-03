using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Generator : MonoBehaviour
{
    public GameObject HubukiPlanet;
    GameObject[] PlanetList;
    int maxCount = 5;

    float freq = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(respawn(Planet));

        PlanetList = new GameObject[maxCount];
        for(int i = 0; i < maxCount; i++)
        {
            GameObject planets = Instantiate(HubukiPlanet, new Vector2(UnityEngine.Random.Range(-50.0f, 50.0f), UnityEngine.Random.Range(-50.0f, 50.0f)), Quaternion.identity);
            planets.transform.localScale = Vector3.one;
            PlanetList[i] = planets;
        }
    }

    //IEnumerator respawn(GameObject monster)
    //{
    //    //Planet = Instantiate(monster, new Vector2(,0), Quaternion.identity);
    //    //GravityObject mob = Planet.GetComponent<GravityObject>();
    //    //yield return new WaitForSeconds(freq);
    //    //StartCoroutine(respawn(monster));
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
