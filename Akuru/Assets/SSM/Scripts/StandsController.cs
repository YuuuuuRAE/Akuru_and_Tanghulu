using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandsController : MonoBehaviour
{
    public Stand[] stands;

    void Awake()
    {
        stands = GetComponentsInChildren<Stand>();
    }

    void Update()
    {
        
    }
}
