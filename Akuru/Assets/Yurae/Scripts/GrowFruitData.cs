using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GrowFruitData
{
    public string FruitsName; // ������ �̸�

    public Sprite flowerIcon; // �� �̹��� ����
    public Sprite MidIcon; // �߰� �ܰ� �̹��� ����
    public Sprite FinIcon; // ���� �ܰ� �̹��� ����

    public float None_Time; //None -> Flower
    public float Flower_Time; // Flower -> Mid
    public float Mid_Time; // Mid -> Fin


    //Contena
    public int FruitsCount; // ���� ������ ����

}
