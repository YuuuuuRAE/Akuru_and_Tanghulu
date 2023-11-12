using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TanghuluSpawner : MonoBehaviour
{
    // 탕후루 종류
    public GameObject[] tanghulus;

    // 현재 진열장에 몇 개가 있는지 체크
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
            // 열려 있는 진열장의 개수만큼 반복
            for (int standNum = 0; standNum < GameManager.instance.openStandNum + 1; standNum++)
            {
                // 모든 탕후루 종류에 대해 반복
                for (int tanghuluNum = 0; tanghuluNum < 5; tanghuluNum++)
                {
                    // 만약 해당 탕후루의 개수가 3이상이면
                    if (GameManager.instance.tangfuruNumList[tanghuluNum] >= 3)
                    {
                        // 각 진열장 중에 진열된 탕후루가 0개인 곳을 찾음
                        if (standIndex[standNum] == 0)
                        {
                            // 탕후루를 생성하고 진열장에 추가
                            InstantiateTanghulu(standNum, tanghuluNum);
                        }
                    }
                }
            }
        }
        else
        {
            // 열려 있는 진열장의 개수만큼 반복
            for (int standNum = 0; standNum < GameManager.instance.openStandNum + 1; standNum++)
            {
                // 모든 탕후루 종류에 대해 반복
                for (int tanghuluNum = 0; tanghuluNum < 5; tanghuluNum++)
                {
                    // 만약 저장된 탕후루의 개수가 0보다 크면
                    if (GameManager.instance.standsNumList[tanghuluNum] > 0)
                    {
                        // 각 진열장 중에 진열된 탕후루가 0개인 곳을 찾음
                        if (standIndex[standNum] == 0)
                        {
                            // 탕후루를 생성하고 진열장에 추가
                            InstantiateTanghulu(standNum, tanghuluNum);
                        }
                    }
                }
            }
        }
    }

    private void InstantiateTanghulu(int standNum, int tanghuluNum)
    {
        // 탕후루를 생성하고 진열장에 추가
        StandsController.stands[standNum].SpawnTanghuluGameObjects(tanghulus[tanghuluNum], 3);
        standIndex[standNum] += 3;
        GameManager.instance.standsNumList[tanghuluNum] += 3;
        GameManager.instance.tangfuruNumList[tanghuluNum]-= 3;
    }
}
