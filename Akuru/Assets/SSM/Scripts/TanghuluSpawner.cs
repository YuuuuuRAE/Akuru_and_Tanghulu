using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TanghuluSpawner : MonoBehaviour
{
    // ���ķ� ����
    public GameObject[] tanghulus;

    // ���� �����忡 �� ���� �ִ��� üũ
    public int[] standIndex;

    public StandsController StandsController;

    public void Start()
    {
        StandsController = FindObjectOfType<StandsController>();

        PurchaseStand();
    }

    public void PurchaseStand()
    {
        if (GameManager.instance.standsNumList.All(value => value == 0))
        {
            // ���� �ִ� �������� ������ŭ �ݺ�
            for (int standNum = 0; standNum < GameManager.instance.openStandNum + 1; standNum++)
            {
                // ��� ���ķ� ������ ���� �ݺ�
                for (int tanghuluNum = 0; tanghuluNum < 5; tanghuluNum++)
                {
                    // ���� �ش� ���ķ��� ������ 3�̻��̸�
                    if (GameManager.instance.tangfuruNumList[tanghuluNum] >= 3)
                    {
                        // �� ������ �߿� ������ ���ķ簡 0���� ���� ã��
                        if (standIndex[standNum] == 0)
                        {
                            // ���ķ縦 �����ϰ� �����忡 �߰�
                            InstantiateTanghulu(standNum, tanghuluNum);
                        }
                    }
                }
            }
        }
        else
        {
            // ���� �ִ� �������� ������ŭ �ݺ�
            for (int standNum = 0; standNum < GameManager.instance.openStandNum + 1; standNum++)
            {
                // ��� ���ķ� ������ ���� �ݺ�
                for (int tanghuluNum = 0; tanghuluNum < 5; tanghuluNum++)
                {
                    // ���� ����� ���ķ��� ������ 0���� ũ��
                    if (GameManager.instance.standsNumList[tanghuluNum] > 0)
                    {
                        // �� ������ �߿� ������ ���ķ簡 0���� ���� ã��
                        if (standIndex[standNum] == 0)
                        {
                            // ���ķ縦 �����ϰ� �����忡 �߰�
                            InstantiateTanghulu(standNum, tanghuluNum);
                        }
                    }
                }
            }
        }
    }

    private void InstantiateTanghulu(int standNum, int tanghuluNum)
    {
        // ���ķ縦 �����ϰ� �����忡 �߰�
        StandsController.stands[standNum].SpawnTanghuluGameObjects(tanghulus[tanghuluNum], 3);
        standIndex[standNum] += 3;
        GameManager.instance.standsNumList[tanghuluNum] += 3;
        GameManager.instance.tangfuruNumList[tanghuluNum]-= 3;
    }
}
