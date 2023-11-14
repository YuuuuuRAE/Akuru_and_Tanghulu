using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefab;
    public int poolSize = 20;

    // 인스턴스로 설정
    public float spawnRateMin;
    public float spawnRateMax;

    private List<GameObject> customerPool;
    private float spawnRate;
    private float timeAfterSpawn;
    private int currentCustomerIndex = 0;

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

            // 오브젝트 풀에서 다음 순서의 손님 가져오기
            GameObject customer = GetNextCustomer();
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
            int customerType = Random.Range(0, GameManager.instance.CurrentLevel); // 랜덤한 손님 타입 선택
            GameObject customer = Instantiate(customerPrefab[customerType], transform.position, transform.rotation);
            customer.SetActive(false); // 초기에는 비활성화 상태로 설정
            customerPool.Add(customer);
        }
    }

    // 다음 순서의 손님 오브젝트 가져오기
    GameObject GetNextCustomer()
    {
        if (customerPool.Count == 0)
        {
            return null; // 풀이 비어있으면 null 반환
        }

        GameObject customer = customerPool[currentCustomerIndex];
        currentCustomerIndex = (currentCustomerIndex + 1) % customerPool.Count; // 다음 순서 계산

        return customer;
    }
}