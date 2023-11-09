using System.Collections.Generic;
using UnityEngine;

public class TanghuluSpawner : MonoBehaviour
{
    // 탕후루 진열장에 스폰
    // 탕후루 종류
    public GameObject[] tanghulus;
    
    // 탕후루가 스폰 될 진열장의 위치
    public Transform[] standPos1;
    public Transform[] standPos2;
    public Transform[] standPos3;
    public Transform[] standPos4;
    public Transform[] standPos5;
    public Transform[] standPos6;
    public Transform[] standPos7;
    public Transform[] standPos8;
    
    public Transform[][] standPosArray = new Transform[8][];

    // 현재 진열장에 몇개가 있는지 체크
    public int[] standIndex;

    // 진열장이 잠겨있는지 체크
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
        // 과일 종류당 한 진열장 사용하게 하기... 수정 필요....
        for (int tanghuluNum = 0; tanghuluNum < 5; tanghuluNum++) // 탕후루 종류만큼 돌리기
        {
            for (int standNum = 0; standNum < 8 - activeCount; standNum++)  // 열려있는 진열장 개수만큼 돌린다
            {
                for (int s1 = 0; s1 < 3; s1++)  // 각 진열장에 탕후루 3개씩 진열
                {
                    if (GameManager.instance.tangfuruNumList[tanghuluNum] > 0)  // 굳히소에 탕후루가 있을 경우
                    {
                        if (standIndex[standNum] < 3)  // 각 진열장 중에 진열된 탕후루가 3개 미만인 곳을 찾는다
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