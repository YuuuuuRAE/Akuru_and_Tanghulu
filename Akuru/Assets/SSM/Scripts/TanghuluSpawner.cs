using System.Collections.Generic;
using UnityEngine;

public class TanghuluSpawner : MonoBehaviour
{
    // ���ķ� �����忡 ����
    // ���ķ� ����
    public GameObject[] tanghulus;
    
    // ���ķ簡 ���� �� �������� ��ġ
    public Transform[] standPos1;
    public Transform[] standPos2;
    public Transform[] standPos3;
    public Transform[] standPos4;
    public Transform[] standPos5;
    public Transform[] standPos6;
    public Transform[] standPos7;
    public Transform[] standPos8;
    
    public Transform[][] standPosArray = new Transform[8][];

    // ���� �����忡 ��� �ִ��� üũ
    public int[] standIndex;

    // �������� ����ִ��� üũ
    public GameObject[] purchase;
    private int activeCount = 0;

    public void Start()
    {
        standPosArray[0] = standPos1;
        standPosArray[1] = standPos2;
        standPosArray[2] = standPos3;
        standPosArray[3] = standPos4;
        standPosArray[4] = standPos5;
        standPosArray[5] = standPos6;
        standPosArray[6] = standPos7;
        standPosArray[7] = standPos8;

        PurchaseStand();
    }

    private void Update()
    {
        for (int i = 0; i < purchase.Length; i++)
        {
            if (purchase[i].activeSelf)
            {
                activeCount++;
            }
        }
    }

    public void PurchaseStand()
    {
        // ���� ������ �� ������ ����ϰ� �ϱ�... ���� �ʿ�....
        for (int tanghuluNum = 0; tanghuluNum < 5; tanghuluNum++) // ���ķ� ������ŭ ������
        {
            for (int standNum = 0; standNum < 8 - activeCount; standNum++)  // �����ִ� ������ ������ŭ ������
            {
                for (int s1 = 0; s1 < 3; s1++)  // �� �����忡 ���ķ� 3���� ����
                {
                    if (GameManager.instance.tangfuruNumList[tanghuluNum] > 0)  // �����ҿ� ���ķ簡 ���� ���
                    {
                        if (standIndex[standNum] < 3)  // �� ������ �߿� ������ ���ķ簡 3�� �̸��� ���� ã�´�
                        {
                            Instantiate(tanghulus[tanghuluNum], standPosArray[standNum][s1].position, Quaternion.identity);
                            standIndex[standNum]++;
                            GameManager.instance.tangfuruNumList[tanghuluNum]--;
                        }
                    }
                }
            }
        }
    }
}