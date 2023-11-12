using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandsController : MonoBehaviour
{
    public Stand[] Stands => _stands;
    private Stand[] _stands;

    // Start is called before the first frame update
    void Awake()
    {
        _stands = GetComponentsInChildren<Stand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
