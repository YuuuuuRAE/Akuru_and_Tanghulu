using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Contena : MonoBehaviour
{
    [SerializeField]
    private ProductionPlant plant;

    public Level level; //���� �÷��̾��� ������ �޾ƿ� Level ����
    [SerializeField]
    private int Unlocklevel = 0; //���� �ر� �ܰ� ������ ������ ���� �÷��̾��� ���� == 1 ~ 5 / Unlock�� ������ 0 ~ 4

    public GameObject[] UIsets; //��ư�� ���� ������ ���� �迭
    int start = 0;

    public Image[] Images; // �ر��� ���� �̹����� ���� �迭
    public Text[] Texts; // ���� ������ ���� Text �迭



    void Update()
    {
        //�ر�
        if(GameControl.Instance.Level - Unlocklevel > 1 && Unlocklevel < 4)                  
        {
            Unlocklevel++;

            Images[Unlocklevel].color = Color.white; //�Ƿ翧 ����

            start += 3;
            int iterator = GameControl.Instance.Level * 3;

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
