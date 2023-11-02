using System.Collections.Generic;
using UnityEngine;

public class TanghuluSpawner : MonoBehaviour
{
    // 탕후루 진열장에 스폰
    // 탕후루 종류
    public GameObject[] tanghulus;
    // 탕후루가 스폰 될 진열장
    public Transform[] stand;
    // 진열장이 잠겨있는지 체크
    public GameObject[] purchase;
    // 진열장의 넘버
    public int standNum;

    int activeStandCount = 0;

    HashSet<Vector3> spawnedLocations = new HashSet<Vector3>();

    void Update() // 이 부분은 사실상 임시(혜수님 파트랑 연계해야함)
    {
        if (Input.GetButtonDown("Jump"))
        {
            foreach (GameObject obj in purchase)
            {
                if (obj.activeSelf)
                {
                    activeStandCount++;
                }
            }

            standNum = stand.Length - activeStandCount;
            activeStandCount = 0;

            for (int i = 0; i < standNum; i++)
            {
                Vector3 spawnPosition = stand[i].position;

                // 이미 생성된 위치인지 확인
                if (!spawnedLocations.Contains(spawnPosition))
                {
                    int tanghuluType = Random.Range(0, tanghulus.Length);
                    GameObject tanghulu = Instantiate(tanghulus[tanghuluType], spawnPosition, Quaternion.identity);

                    // 생성된 위치를 기록
                    spawnedLocations.Add(spawnPosition);
                }
            }
        }
    }
}