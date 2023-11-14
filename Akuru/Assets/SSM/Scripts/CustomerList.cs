using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerList : MonoBehaviour
{
    public GameObject customerList;
    public GameObject counter;

    // 손님 리스트
    public GameObject customerImg;
    private int currentCustomersNum;
    public Text customerName;
    public Text customerInst;
    public Sprite[] customersSprite;

    // 호감도 관련
    public float likability;
    public Text currentDrop;
    public Text nextDrop;


    // 선물 드롭 확률 배열
    public float[][] dropValues = {
        new float[] { 1.0f, 2.0f, 4.0f, 6.0f },
        new float[] { 1.0f, 2.0f, 4.0f, 7.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 8.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 9.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 10.0f }
    };

    public void Start()
    {
        counter = GameObject.Find("Counter");

    }

    // 손님 리스트 UI 관련
    // 손님 리스트 UI 오픈
    public void ListOpen()
    {
        currentCustomersNum = 0;

        if (counter != null)
        {
            likability = counter.GetComponent<Counter>().salesCount[currentCustomersNum];
        }

        customerList.SetActive(true);
        ListChange();
    }

    // 손님 리스트 좌 버튼
    public void ListLeft()
    {
        currentCustomersNum--;

        if (currentCustomersNum < 0)
        {
            currentCustomersNum = 4;
        }

        if (counter != null)
        {
            likability = counter.GetComponent<Counter>().salesCount[currentCustomersNum];
        }

        ListChange();
    }

    // 손님 리스트 우 버튼
    public void ListRight()
    {
        currentCustomersNum++;

        if (currentCustomersNum >= 5)
        {
            currentCustomersNum = 0;
        }

        if (counter != null)
        {
            likability = counter.GetComponent<Counter>().salesCount[currentCustomersNum];
        }

        ListChange();
    }

    // 손님 리스트 정보 전환
    public void ListChange()
    {
        switch (currentCustomersNum)
        {
            case 0:
                customerName.text = "딸기콩";
                customerInst.text = "딸기 탕후루를 좋아하는 아쿠루\n사랑스러운 미소를 지으며 달콤함을 느끼는 중";
                customerImg.GetComponent<Image>().sprite = customersSprite[0];
                SetDropValues(0);
                break;
            case 1:
                customerName.text = "청포뿌";

                if (GameManager.instance.CurrentLevel >= 2)
                {
                    customerInst.text = "청포도 탕후루를 좋아하는 아쿠루.\n재미있는 몸짓으로 주변을 환하게 밝힌다.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[1];
                }
                else
                {
                    customerInst.text = "청포도 탕후루를 진열하면 찾아오는 아쿠루.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[2];
                }
                SetDropValues(1);
                break;
            case 2:
                customerName.text = "귤랑";
                if (GameManager.instance.CurrentLevel >= 3)
                {
                    customerInst.text = "귤 탕후루를 좋아하는 아쿠루.\n호기심이 많아 이것저것 건드리다 자주 다친다.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[3];
                }
                else
                {
                    customerInst.text = "귤 탕후루를 진열하면 찾아오는 아쿠루.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[4];
                }
                SetDropValues(2);
                break;
            case 3:
                customerName.text = "파인토";
                if (GameManager.instance.CurrentLevel >= 4)
                {
                    customerInst.text = "파인애플 탕후루를 좋아하는 아쿠루.\n여기저기 돌아다니는 것을 좋아한다.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[5];
                }
                else
                {
                    customerInst.text = "파인애플 탕후루를 진열하면 찾아오는 아쿠루.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[6];
                }
                SetDropValues(3);
                break;
            case 4:
                customerName.text = "블루포";
                if (GameManager.instance.CurrentLevel >= 5)
                {
                    customerInst.text = "블루베리 탕후루를 좋아하는 아쿠루.\n폴짝 폴짝 뛰어다니기를 좋아한다.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[7];
                }
                else
                {
                    customerInst.text = "블루베리 탕후루를 진열하면 찾아오는 아쿠루.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[8];
                }
                SetDropValues(4);
                break;
            default:
                break;
        }
    }

    private void SetDropValues(int index)
    {
        if (likability >= 300)
        {
            currentDrop.text = dropValues[index][3].ToString();
            nextDrop.text = dropValues[index][3].ToString();
        }
        else if (likability >= 200)
        {
            currentDrop.text = dropValues[index][2].ToString();
            nextDrop.text = dropValues[index][3].ToString();
        }
        else if (likability >= 100)
        {
            currentDrop.text = dropValues[index][1].ToString();
            nextDrop.text = dropValues[index][2].ToString();
        }
        else if (likability >= 0)
        {
            currentDrop.text = dropValues[index][0].ToString();
            nextDrop.text = dropValues[index][1].ToString();
        }
    }

    // 손님 리스트 UI 닫기
    public void ListClose()
    {
        customerList.SetActive(false);
    }
}
