using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TanghuluSpawner : MonoBehaviour
{
    // ���ķ� ����
    public GameObject[] tanghulus;

    // ���� �����忡 �� ���� �ִ��� üũ
    public int[] standIndex;

    public int standCount;
    public int remainder;

    public StandsController StandsController;

    public void Start()
    {
        StandsController = FindObjectOfType<StandsController>();

        standCount = 1;

        InstantiateTanghulu();
    }

    public void InstantiateTanghulu()
    {
        int standNum = 0;

        for (int tanghuluNum = 0; tanghuluNum < 5; tanghuluNum++)
        {
            int tanghuluCount = GameManager.instance.standsNumList[tanghuluNum];

            for (int i = 0; i < tanghuluCount; i++)
            {
                remainder = standCount % 3;

                StandsController.stands[standNum].SpawnTanghuluGameObjects(tanghulus[tanghuluNum], remainder);
                standCount++;

                if (remainder == 0)
                {
                    standNum += 1;
                }
            }
        }
    }
}
