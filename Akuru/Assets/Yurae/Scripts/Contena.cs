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

    public GameObject[] UIsets; //버튼과 과일 갯수에 대한 배열

    public Image[] Images; // 해금할 과일 이미지에 대한 배열
    public Text[] Texts; // 과일 갯수에 대한 Text 배열

    public GameObject[] FirstTrim_Butt;

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
                Images[i].color = Color.white; //실루엣 제거
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

        TrimButton();
        UpdateCount();

    }

    void UpdateCount()
    {
        for (int i = 0; i < plant.growFruitDatas.Length; i++)
        {
            Texts[i].text = GameManager.instance.fruitNumList[i].ToString();
        }
    }

    void TrimButton()
    {
        if (GameManager.instance.isSelectFT == true)
        {
            for (int i = 0; i < GameManager.instance.fruit_FirstMaking.Count; i++)
            {
                FirstTrim_Butt[i].GetComponent<Button>().interactable
                    = GameManager.instance.fruit_FirstMaking[i];
            }
        }

    }

    public void SelectFrisrtTrim(int firstCheckIndex)
    {
        if (GameManager.instance.isSelectFT == false)
        {
            GameManager.instance.isSelectFT = true;
            for (int i = 0; i < GameManager.instance.fruit_FirstMaking.Count; i++)
            {
                if (i == firstCheckIndex)
                {
                    GameManager.instance.fruit_FirstMaking[i] = true;
                }
                else GameManager.instance.fruit_FirstMaking[i] = false;
            }
        }
        else
        {
            GameManager.instance.isSelectFT = false;

            for (int i = 0; i < GameManager.instance.fruit_FirstMaking.Count; i++)
            {
                GameManager.instance.fruit_FirstMaking[i] = false;
                FirstTrim_Butt[i].GetComponent<Button>().interactable = true;
            }
        }


    }


}
