using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class RoulettePieceData : MonoBehaviour
{
    public Sprite icon; //아이콘 이미지 파일
    public string description; //이름, 속성, 능력치 등의 정보

    //3개의 아이템 등장확률(chance) 100, 60, 40이면
    //등장 확률의 합은 200 100/200 = 50 ...

    [Range(1, 100)]
    public int chance = 100; //등장 확률

    [HideInInspector]
    public int index; // 아이템 순번

    [HideInInspector]
    public int weight;
}
