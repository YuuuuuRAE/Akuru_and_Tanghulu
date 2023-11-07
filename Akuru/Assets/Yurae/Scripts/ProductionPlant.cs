using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionPlant : MonoBehaviour
{
    public GameObject Player;

    [SerializeField]
    private GameObject[] Fruits; //ǥ�õǴ� ���� ���� ������Ʈ �迭

    [SerializeField]
    private int MaxFruitsType;

    public GrowFruitData[] growFruitDatas;

    void Update()
    {
        SetFruitsType();
        SpawnFruits();
    }

    public void SetFruitsType()
    {
        MaxFruitsType = Player.GetComponent<Level>().PlayerLevel; //���� ���� ������ ������ ������ �÷��� ���� ��ŭ ����
    }

    public void SpawnFruits()
    {
        for (int i = 0; i < Fruits.Length; i++)
        {
            int randomFruits = Random.Range(0, MaxFruitsType);
            if (Fruits[i].GetComponent<GrowFruit>().isGrowing == false &&
                Fruits[i].GetComponent<GrowFruit>().isGathering == true) //���� ���� �ƴϰ� ä���� �Ǿ��� �� ���Ӱ� �Ҵ�
            {
                Fruits[i].GetComponent<GrowFruit>().SetUp(growFruitDatas[randomFruits]);
            }
        }
    }
}
