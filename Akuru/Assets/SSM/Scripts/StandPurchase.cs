using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandPurchase : MonoBehaviour
{
    public GameObject purchaseStand;

    // ������ �߰� â
    public GameObject[] purchase;
    public int purchaseNum;

    // �� ���½� ������ ����
    public void Start()
    {
        for (int i = 0; i < GameManager.instance.openStandNum; i++)
        {
            purchase[i].SetActive(false);
        }
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
        }
    }

    // ������ �ݱ�
    public void PurchaseClose()
    {
        purchaseStand.SetActive(false);
    }
}
