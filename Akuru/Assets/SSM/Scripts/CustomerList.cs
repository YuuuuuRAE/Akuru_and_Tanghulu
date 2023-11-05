using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerList : MonoBehaviour
{
    public GameObject customerList;

    // 손님 리스트
    public GameObject[] customers;
    private int currentCustomersNum;
    public Text customerName;
    public Text customerInst;
    public Text likeability;

    // 손님 리스트 UI 관련
    // 손님 리스트 UI 오픈
    public void ListOpen()
    {
        currentCustomersNum = 0;
        customerList.SetActive(true);
        ListChange();
    }

    // 손님 리스트 좌 버튼
    public void ListLeft()
    {
        currentCustomersNum--;

        if (currentCustomersNum < 0)
        {
            currentCustomersNum = customers.Length - 1;
        }
        ListChange();
    }

    // 손님 리스트 우 버튼
    public void ListRight()
    {
        currentCustomersNum++;

        if (currentCustomersNum >= customers.Length)
        {
            currentCustomersNum = 0;
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
                break;
            case 1:
                customerName.text = "청포뿌";
                customerInst.text = "청포도 탕후루를 좋아하는 아쿠루.\n재미있는 몸짓으로 주변을 환하게 밝힌다.";
                break;
            case 2:
                customerName.text = "귤랑";
                customerInst.text = "귤 탕후루를 좋아하는 아쿠루.\n호기심이 많아 이것저것 건드리다 자주 다친다.";
                break;
            case 3:
                customerName.text = "파인토";
                customerInst.text = "파인애플 탕후루를 좋아하는 아쿠루.\n여기저기 돌아다니는 것을 좋아한다.";
                break;
            case 4:
                customerName.text = "블루포";
                customerInst.text = "블루베리 탕후루를 좋아하는 아쿠루.\n폴짝 폴짝 뛰어다니기를 좋아한다.";
                break;
            default:
                break;
        }

        for (int i = 0; i < customers.Length; i++)
        {
            if (i == currentCustomersNum)
            {
                customers[i].SetActive(true);
            }
            else
            {
                customers[i].SetActive(false);
            }
        }
    }

    // 손님 리스트 UI 닫기
    public void ListClose()
    {
        customerList.SetActive(false);
    }
}
