using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionPlant : MonoBehaviour
{
    public GameObject Player;

    [SerializeField]
    private GameObject[] Fruits; //표시되는 과일 게임 오브젝트 배열

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
        MaxFruitsType = Player.GetComponent<Level>().PlayerLevel; //현재 생성 가능한 과일의 종류를 플레이 레벨 만큼 설정
    }

    public void SpawnFruits()
    {
        for (int i = 0; i < Fruits.Length; i++)
        {
            int randomFruits = Random.Range(0, MaxFruitsType);
            if (Fruits[i].GetComponent<GrowFruit>().isGrowing == false &&
                Fruits[i].GetComponent<GrowFruit>().isGathering == true) //성장 중이 아니고 채집이 되었을 때 새롭게 할당
            {
                Fruits[i].GetComponent<GrowFruit>().SetUp(growFruitDatas[randomFruits]);
            }
        }
    }
}
