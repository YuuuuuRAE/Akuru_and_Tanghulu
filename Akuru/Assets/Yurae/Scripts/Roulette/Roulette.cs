using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    private Transform piecePrefab; // �귿�� ǥ�õǴ� ���� ������
    [SerializeField]
    private Transform linePrefab; // ���� ���� �� ������
    [SerializeField]
    private Transform pieceParent; //�������� ��ġ�Ǵ� �θ� Transform
    [SerializeField]
    private Transform lineParent; // ������ ��ġ�Ǵ� �θ� Transform
    [SerializeField]
    private RoulettePieceData[] roulettePieceData; // �귿�� ǥ�õǴ� ���� �迭


    // Update is called once per frame
    void Update()
    {
        
    }
}
