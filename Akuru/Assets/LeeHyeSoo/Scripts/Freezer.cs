using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Freezer : MonoBehaviour
{
    public GameObject freezerNum;

    public Text freezertangfuruNum;
    

    //[Header("≥√¿Â∞Ì æ»")]
    //public List<Fruit> inFreezer;

    FreezeTangfuru freezeTangfuru;

    int index; //≥√¿Â∞Ì ¿Œµ¶Ω∫

    private void Awake()
    {
        freezeTangfuru = FindAnyObjectByType<FreezeTangfuru>();

    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            if (freezerNum.name == "FullFreezer(" + i + ")")
            {
                index = i;
            }
        }
        
    }

    private void Update()
    {
        freezertangfuruNum.text = GameManager.instance.tangfuruNumList[index].ToString();
    }

    public void ClickFreezer_GoToSalse()
    {
        


        if (GameManager.instance.tangfuruNumList[index] > 0)
        {

            freezeTangfuru.tangfuruNumInFreezerNow[index] -= 1;

        }
    }
}
