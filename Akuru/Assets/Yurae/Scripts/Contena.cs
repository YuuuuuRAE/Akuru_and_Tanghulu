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

    public GameObject[] UIsets; //��ư�� ���� ������ ���� �迭

    public Image[] Images; // �ر��� ���� �̹����� ���� �迭
    public Text[] Texts; // ���� ������ ���� Text �迭



    void Update()
    {


        if (!GameManager.instance.isUnlock)
        {
            for (int i = 0; i < GameManager.instance.CurrentLevel * 3; i++)
            {
                UIsets[i].SetActive(true);
            }

            for (int i = 0; i < GameManager.instance.MaxFruitType; i++)
            {
                Images[i].color = Color.white; //�Ƿ翧 ����
            }
        }
        else
        {
            for (int i = 0; i < UIsets.Length; i++)
            {
                UIsets[i].SetActive(true);
            }
            for (int i = 0; i < Images.Length; i++)
            {
                Images[i].color = Color.white;
            }
        }


        UpdateCount();

    }

    void UpdateCount()
    {
        for (int i = 0; i < plant.growFruitDatas.Length; i++)
        {
            Texts[i].text = GameManager.instance.fruitNumList[i].ToString();
        }
    }

}
