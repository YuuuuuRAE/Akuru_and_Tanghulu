using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GrowFruitData
{
    public string FruitsName; // 과일의 이름

    public Sprite flowerIcon; // 꽃 이미지 파일
    public Sprite MidIcon; // 중간 단계 이미지 파일
    public Sprite FinIcon; // 최종 단계 이미지 파일

    public float None_Time; //None -> Flower
    public float Flower_Time; // Flower -> Mid
    public float Mid_Time; // Mid -> Fin


    //Contena
    public int FruitsCount; // 현재 과일의 개수

}
