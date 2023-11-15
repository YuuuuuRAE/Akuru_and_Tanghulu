using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingSpawner : MonoBehaviour
{
    public int index; // 좌 1, 우 -1 인스펙터 창에서 설정하기
    public GameObject[] passingPrefab;
    public int poolSize = 20;
    public float spawnRateMin;
    public float spawnRateMax;
    public int passingRange;

    private List<GameObject> passingPool;
    private float spawnRate;
    private float timeAfterSpawn;
    private int currentPassingIndex = 0;

    public GameObject target;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        for (int i = 0; i < GameManager.instance.lockFreezer.Count; i++)
        {
            if (GameManager.instance.lockFreezer[i])
            {
                passingRange++;
            }
        }

        // 오브젝트 풀 초기화
        InitializeObjectPool();
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            // 오브젝트 풀에서 다음 순서의 손님 가져오기
            GameObject customer = GetNextPassing();
            if (customer != null)
            {
                // 활성화 상태로 만들고 위치, 회전 설정
                customer.SetActive(true);
                customer.transform.position = GetRandomSpawnPosition();
                customer.transform.rotation = transform.rotation;
            }

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    // 오브젝트 풀 초기화
    void InitializeObjectPool()
    {
        passingPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int passingType = Random.Range(0, passingRange + 1); // 랜덤한 손님 타입 선택
            GameObject passing = Instantiate(passingPrefab[passingType]);
            Passing passingScript = passing.GetComponent<Passing>();

            // Passing의 타겟 설정
            passingScript.target = target;

            // Passing의 움직임 설정
            passingScript.index = index;

            // 랜덤한 위치 설정
            Vector3 randomPosition = GetRandomSpawnPosition();
            passing.transform.position = randomPosition;

            // passingSpawner의 회전과 동일하게 설정
            passing.transform.rotation = transform.rotation;

            passing.SetActive(false); // 초기에는 비활성화 상태로 설정
            passingPool.Add(passing);
        }
    }


    GameObject GetNextPassing()
    {
        if (passingPool.Count == 0)
        {
            return null; // 풀이 비어있으면 null 반환
        }

        GameObject customer = passingPool[currentPassingIndex];
        currentPassingIndex = (currentPassingIndex + 1) % passingPool.Count; // 다음 순서 계산

        return customer;
    }

    Vector3 GetRandomSpawnPosition()
    {
        // passingSpawner의 콜라이더 범위 내에서 랜덤한 위치 생성
        float randomX = Random.Range(transform.position.x - transform.localScale.x / 2f, transform.position.x + transform.localScale.x / 2f);
        float randomY = Random.Range(transform.position.y - transform.localScale.y / 2f, transform.position.y + transform.localScale.y / 2f);
        float randomZ = transform.position.z;

        return new Vector3(randomX, randomY, randomZ);
    }
}
