using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefab; // 단일 손님 프리팹을 사용
    public int poolSize = 10; // 오브젝트 풀 크기
    public float spawnRateMin = 3f;
    public float spawnRateMax = 5f;

    private List<GameObject> customerPool;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // 오브젝트 풀 초기화
        InitializeObjectPool();
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            // 오브젝트 풀에서 비활성화된 손님 찾기
            GameObject customer = GetInactiveCustomer();
            if (customer != null)
            {
                // 활성화 상태로 만들고 위치, 회전 설정
                customer.SetActive(true);
                customer.transform.position = transform.position;
                customer.transform.rotation = transform.rotation;
            }

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    // 오브젝트 풀 초기화
    void InitializeObjectPool()
    {
        customerPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int customerType = Random.Range(0, customerPrefab.Length);
            GameObject customer = Instantiate(customerPrefab[customerType], transform.position, transform.rotation);
            customer.SetActive(false); // 초기에는 비활성화 상태로 설정
            customerPool.Add(customer);
        }
    }

    // 비활성화된 손님 오브젝트 찾기
    GameObject GetInactiveCustomer()
    {
        foreach (GameObject customer in customerPool)
        {
            if (!customer.activeInHierarchy)
            {
                return customer;
            }
        }

        return null;
    }
}