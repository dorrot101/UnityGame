using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class timer : MonoBehaviour
{
    public glbTimer glbtimer;
    TextMeshProUGUI textmeshpro;

    // Start is called before the first frame update
    void Start()
    {
        glbtimer = GetComponent<glbTimer>();
        textmeshpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        var gg = GameObject.Find("GlobalTimer").GetComponent<glbTimer>().gametimer;
        textmeshpro.text = gg.ToString();
    }
}
