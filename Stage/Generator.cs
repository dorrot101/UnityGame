using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Generator : MonoBehaviour
{
    public GameObject HubukiPlanet;
    public GameObject SpeedUpItem;
    public GameObject SpeedDownItem;

    GameObject[] PlanetList;

    int maxCount = 75;

    float territory = 250.0f;
    int sideSector = 5;
    float territoryPerSector;


    // Start is called before the first frame update
    void Awake()
    {

        PlanetList = new GameObject[maxCount];

        GenerateMap();
    }
    
    void GenerateMap()
    {
        territoryPerSector = territory / sideSector;

        var center = Vector2.zero;
        var i = 0;

        for (int sectorXpos = 0; sectorXpos < sideSector; sectorXpos++)
        {
            for (int sectorYpos = 0; sectorYpos < sideSector; sectorYpos++)
            {
                var xpos = UnityEngine.Random.Range(sectorXpos * territoryPerSector, (sectorXpos + 1) * territoryPerSector) - territory / 2;
                var ypos = UnityEngine.Random.Range(sectorYpos * territoryPerSector, (sectorYpos + 1) * territoryPerSector) - territory / 2;

                GameObject planets = Instantiate(HubukiPlanet, new Vector2(xpos, ypos), Quaternion.identity);
                PlanetList[i++] = planets;
            }
        }
    }

    
}
