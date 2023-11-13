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

        AddLists();

        PurchaseStand();
    }

    public void PurchaseStand()
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

    public void AddLists()
    {
        // ���� �� ����Ʈ�� ���̰� ������� ���� (���� üũ)
        if (GameManager.instance.tangfuruNumList.Length == GameManager.instance.standsNumList.Length)
        {
            for (int i = 0; i < GameManager.instance.tangfuruNumList.Length; i++)
            {
                // �����ؾ��ϴ� ���ķ� �޾ƿ���
                GameManager.instance.tangfuruNumList[i] += GameManager.instance.standsNumList[i];
                // �����뿡 �ִ� ���ķ� ���� �ʱ�ȭ
                GameManager.instance.standsNumList[i] = 0;
            }
        }
        else
        {
            Debug.Log("�� ����Ʈ�� ���̰� �ٸ��ϴ�. ���ϴ� �۾��� ������ �� �����ϴ�.");
        }
    }

    private void InstantiateTanghulu(int standNum, int tanghuluNum)
    {
        // ���ķ縦 3���� �����ϰ� �����忡 �߰�
        StandsController.stands[standNum].SpawnTanghuluGameObjects(tanghulus[tanghuluNum], 3);
        standIndex[standNum] += 1;
        GameManager.instance.tangfuruNumList[tanghuluNum] -= 3;
        GameManager.instance.standsNumList[tanghuluNum] += 3;
    }
}
