using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionPlant : MonoBehaviour
{
    [SerializeField]
    private Transform FruitsPrefab; //ǥ�õǴ� ���� ������
    [SerializeField]
    private Transform FruitsParent; // ���� �θ� Transform
    [SerializeField]
    private GrowFruitData[] growFruitDatas;
}
