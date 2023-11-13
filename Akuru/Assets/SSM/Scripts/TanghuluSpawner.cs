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

        AddLists();

        PurchaseStand();
    }

    public void PurchaseStand()
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

    public void AddLists()
    {
        // 만약 두 리스트의 길이가 같을경우 실행 (버그 체크)
        if (GameManager.instance.tangfuruNumList.Length == GameManager.instance.standsNumList.Length)
        {
            for (int i = 0; i < GameManager.instance.tangfuruNumList.Length; i++)
            {
                // 진열해야하는 탕후루 받아오기
                GameManager.instance.tangfuruNumList[i] += GameManager.instance.standsNumList[i];
                // 진열대에 있는 탕후루 개수 초기화
                GameManager.instance.standsNumList[i] = 0;
            }
        }
        else
        {
            Debug.Log("두 리스트의 길이가 다릅니다. 더하는 작업을 수행할 수 없습니다.");
        }
    }

    private void InstantiateTanghulu(int standNum, int tanghuluNum)
    {
        // 탕후루를 3개씩 생성하고 진열장에 추가
        StandsController.stands[standNum].SpawnTanghuluGameObjects(tanghulus[tanghuluNum], 3);
        standIndex[standNum] += 1;
        GameManager.instance.tangfuruNumList[tanghuluNum] -= 3;
        GameManager.instance.standsNumList[tanghuluNum] += 3;
    }
}
