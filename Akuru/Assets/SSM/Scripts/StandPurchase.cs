using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandPurchase : MonoBehaviour
{
    public GameObject purchaseStand;

    // 진열장 추가 창
    public GameObject[] purchase;
    public Button[] purahseBtns;
    public int purchaseNum;

    // 씬 오픈시 진열장 오픈
    public void Start()
    {
        for (int i = 0; i < GameManager.instance.openStandNum; i++)
        {
            purchase[i].SetActive(false);
        }
        purahseBtns[GameManager.instance.openStandNum].gameObject.SetActive(true);
    }

    // 진열장 구매 UI 오픈
    public void PurchaseOpen(int buttonIndex)
    {
        if (buttonIndex == 0 || !purchase[(buttonIndex - 1)].activeSelf)
        {
            purchaseNum = buttonIndex;
            purchaseStand.SetActive(true);
        }
    }

    // 진열장 구매
    public void Purchase()
    {
        if (GameManager.instance.currentCoin >= 200)
        {
            GameManager.instance.currentCoin -= 200;
            purchaseStand.SetActive(false);
            purchase[purchaseNum].SetActive(false);
            GameManager.instance.openStandNum++;
            if (GameManager.instance.openStandNum <= 5)
            purahseBtns[GameManager.instance.openStandNum].gameObject.SetActive(true);
        }
    }

    // 진열장 닫기
    public void PurchaseClose()
    {
        purchaseStand.SetActive(false);
    }
}
