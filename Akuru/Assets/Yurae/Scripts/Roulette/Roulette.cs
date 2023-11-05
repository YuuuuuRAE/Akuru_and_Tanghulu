using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    private Transform piecePrefab; // 룰렛에 표시되는 정보 프리팹
    [SerializeField]
    private Transform linePrefab; // 정보 구분 선 프리팹
    [SerializeField]
    private Transform pieceParent; //정보들이 배치되는 부모 Transform
    [SerializeField]
    private Transform lineParent; // 선들이 배치되는 부모 Transform
    [SerializeField]
    private RoulettePieceData[] roulettePieceData; // 룰렛에 표시되는 정보 배열


    // Update is called once per frame
    void Update()
    {
        
    }
}
