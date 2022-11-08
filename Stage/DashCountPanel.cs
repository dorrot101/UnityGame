using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DashCountPanel : MonoBehaviour
{
    TextMeshProUGUI textmeshpro;
    RotateObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Playable_planet").gameObject.GetComponent<RotateObject>();
        textmeshpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textmeshpro.text = player.getDashCount.ToString();
    }
}
