using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefab; // ���� �մ� �������� ���
    public int poolSize = 10; // ������Ʈ Ǯ ũ��
    public float spawnRateMin = 3f;
    public float spawnRateMax = 5f;

    private List<GameObject> customerPool;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // ������Ʈ Ǯ �ʱ�ȭ
        InitializeObjectPool();
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            // ������Ʈ Ǯ���� ��Ȱ��ȭ�� �մ� ã��
            GameObject customer = GetInactiveCustomer();
            if (customer != null)
            {
                // Ȱ��ȭ ���·� ����� ��ġ, ȸ�� ����
                customer.SetActive(true);
                customer.transform.position = transform.position;
                customer.transform.rotation = transform.rotation;
            }

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    // ������Ʈ Ǯ �ʱ�ȭ
    void InitializeObjectPool()
    {
        customerPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int customerType = Random.Range(0, customerPrefab.Length);
            GameObject customer = Instantiate(customerPrefab[customerType], transform.position, transform.rotation);
            customer.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ ���·� ����
            customerPool.Add(customer);
        }
    }

    // ��Ȱ��ȭ�� �մ� ������Ʈ ã��
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