using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamics : MonoBehaviour
{
    Hashtable m_Dictionary = new Hashtable();

    private void Start()
    {
        m_Dictionary.Add("fortississimo", 1.75);
        m_Dictionary.Add("fortissimo", 1.5);
        m_Dictionary.Add("forte", 1.25);
        m_Dictionary.Add("mezzoforte", 1.125);
        m_Dictionary.Add("mezzopiano", 0.875);
        m_Dictionary.Add("piano", 0.75);
        m_Dictionary.Add("pianissimo", 0.5);
        m_Dictionary.Add("pianississimo", 0.25);
    }

    public float getVelocity(string dynamic)
    {
        return (float)m_Dictionary[dynamic];
    }
}
