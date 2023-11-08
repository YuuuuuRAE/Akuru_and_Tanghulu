using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Contena : MonoBehaviour
{
    [SerializeField]
    private ProductionPlant plant;

    public Level level; //현재 플레이어의 레벨을 받아올 Level 변수
    [SerializeField]
    private int Unlocklevel = 0; //현재 해금 단계 레벨을 저장할 변수 플레이어의 레벨 == 1 ~ 5 / Unlock의 레벨은 0 ~ 4

    public GameObject[] UIsets; //버튼과 과일 갯수에 대한 배열
    int start = 0;

    public Image[] Images; // 해금할 과일 이미지에 대한 배열
    public Text[] Texts; // 과일 갯수에 대한 Text 배열



    void Update()
    {
        //해금
        if(level.PlayerLevel - Unlocklevel > 1)
        {
            Unlocklevel++;

            Images[Unlocklevel].color = Color.white; //실루엣 제거

            start += 3;
            int iterator = level.PlayerLevel * 3;

            for (int i = start; i < iterator; i++)
            {
                UIsets[i].SetActive(true);
            }
        }

        UpdateCount();

    }

    void UpdateCount()
    {
        for (int i = 0; i < plant.growFruitDatas.Length; i++)
        {
            Texts[i].text = plant.growFruitDatas[i].FruitsCount.ToString();
        }
    }

}
