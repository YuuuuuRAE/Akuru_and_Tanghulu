using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandPurchase : MonoBehaviour
{
    public GameObject purchaseStand;

    // ������ �߰� â
    public GameObject[] purchase;
    public int purchaseNum;

    // ������ ���� UI ����
    public void PurchaseOpen(int buttonIndex)
    {
        if (buttonIndex == 0 || !purchase[(buttonIndex - 1)].activeSelf)
        {
            purchaseNum = buttonIndex;
            purchaseStand.SetActive(true);
            Debug.Log((purchaseNum + 2) + "�� ������ ����");
        }
        else
        {
            Debug.Log("���� �������� ���� �ر����ּ���");
        }
    }

    // ������ ����
    public void Purchase()
    {
        if (GameManager.instance.currentCoin >= 200)
        {
            GameManager.instance.currentCoin -= 200;
            Debug.Log("���� ���� : " + GameManager.instance.currentCoin);
            purchaseStand.SetActive(false);
            purchase[purchaseNum].SetActive(false);
            Debug.Log((purchaseNum + 2) + "�� ������ �ر�");
        }
        else
        {
            Debug.Log("������ �����մϴ�.");
        }
    }

    // ������ �ݱ�
    public void PurchaseClose()
    {
        purchaseStand.SetActive(false);
    }
}
