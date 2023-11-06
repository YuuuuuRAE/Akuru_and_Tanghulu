using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionPlant : MonoBehaviour
{
    [SerializeField]
    private Transform FruitsPrefab; //표시되는 과일 프리팹
    [SerializeField]
    private Transform FruitsParent; // 과일 부모 Transform
    [SerializeField]
    private GrowFruitData[] growFruitDatas;
}
