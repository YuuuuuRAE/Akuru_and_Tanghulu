using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Freezer : MonoBehaviour
{
    public GameObject freezerNum;

    public Text freezertangfuruNum;

    [Header("����� ��")]
    public List<Fruit> inFreezer;

    int index; //����� �ε���

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            if (freezerNum.name == "FullFreezer(" + i + ")")
            {
                index = i;
                Debug.Log(index);
            }
        }
        
    }

    private void Update()
    {
        freezertangfuruNum.text = GameManager.instance.tangfuruNumList[index].ToString();
    }


}
