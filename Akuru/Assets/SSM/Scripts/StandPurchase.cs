using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandPurchase : MonoBehaviour
{
    public GameObject purchaseStand;

    // 진열장 추가 창
    public GameObject[] purchase;
    public int purchaseNum;

    // 씬 오픈시 진열장 오픈
    public void Start()
    {
        for (int i = 0; i < GameManager.instance.openStandNum; i++)
        {
            purchase[i].SetActive(false);
        }
    }

    // 진열장 구매 UI 오픈
    public void PurchaseOpen(int buttonIndex)
    {
        if (buttonIndex == 0 || !purchase[(buttonIndex - 1)].activeSelf)
        {
            purchaseNum = buttonIndex;
            purchaseStand.SetActive(true);
            Debug.Log((purchaseNum + 3) + "번 진열장 선택");
        }
        else
        {
            Debug.Log("이전 진열장을 먼저 해금해주세요");
        }
    }

    // 진열장 구매
    public void Purchase()
    {
        if (GameManager.instance.currentCoin >= 200)
        {
            GameManager.instance.currentCoin -= 200;
            Debug.Log("남은 코인 : " + GameManager.instance.currentCoin);
            purchaseStand.SetActive(false);
            purchase[purchaseNum].SetActive(false);
            Debug.Log((purchaseNum + 3) + "번 진열장 해금");
            GameManager.instance.openStandNum++;
        }
        else
        {
            Debug.Log("코인이 부족합니다.");
        }
    }

    // 진열장 닫기
    public void PurchaseClose()
    {
        purchaseStand.SetActive(false);
    }
}
