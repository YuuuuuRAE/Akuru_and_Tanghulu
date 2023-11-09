using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSingleTon : MonoBehaviour
{
    public static CanvasSingleTon Instance;
    //SingleTon
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
