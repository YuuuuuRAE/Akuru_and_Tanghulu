using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandPurchase : MonoBehaviour
{
    public GameObject purchaseStand;

    // ������ �߰� â
    public GameObject[] purchase;
    public Button[] purahseBtns;
    public int purchaseNum;

    // �� ���½� ������ ����
    public void Start()
    {
        for (int i = 0; i < GameManager.instance.openStandNum; i++)
        {
            purchase[i].SetActive(false);
        }
        purahseBtns[GameManager.instance.openStandNum].gameObject.SetActive(true);
    }

    // ������ ���� UI ����
    public void PurchaseOpen(int buttonIndex)
    {
        if (buttonIndex == 0 || !purchase[(buttonIndex - 1)].activeSelf)
        {
            purchaseNum = buttonIndex;
            purchaseStand.SetActive(true);
        }
    }

    // ������ ����
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

    // ������ �ݱ�
    public void PurchaseClose()
    {
        purchaseStand.SetActive(false);
    }
}
