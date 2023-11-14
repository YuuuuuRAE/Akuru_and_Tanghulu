using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefab;
    public int poolSize = 20;

    // �ν��Ͻ��� ����
    public float spawnRateMin;
    public float spawnRateMax;

    public int customerRange;

    private List<GameObject> customerPool;
    private float spawnRate;
    private float timeAfterSpawn;
    private int currentCustomerIndex = 0;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        for (int i = 0; i < GameManager.instance.lockFreezer.Count; i++)
        {
            if (GameManager.instance.lockFreezer[i])
            {
                customerRange++;
            }
        }

        // ������Ʈ Ǯ �ʱ�ȭ
        InitializeObjectPool();
    }

    void Update()
    {
        // ���� Ȱ��ȭ�� �մ��� ���� Ȯ��
        int activeCustomerCount = GetActiveCustomerCount();

        // Ȱ��ȭ�� �մ��� 4�� ������ ���� ���� ���� ����
        if (activeCustomerCount <= 3)
        {
            timeAfterSpawn += Time.deltaTime;

            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                // ������Ʈ Ǯ���� ���� ������ �մ� ��������
                GameObject customer = GetNextCustomer();
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
    }

    // ������Ʈ Ǯ �ʱ�ȭ
    void InitializeObjectPool()
    {
        customerPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int customerType = Random.Range(0, customerRange + 1); // ������ �մ� Ÿ�� ����
            GameObject customer = Instantiate(customerPrefab[customerType], transform.position, transform.rotation);
            customer.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ ���·� ����
            customerPool.Add(customer);
        }
    }

    // ���� ������ �մ� ������Ʈ ��������
    GameObject GetNextCustomer()
    {
        if (customerPool.Count == 0)
        {
            return null; // Ǯ�� ��������� null ��ȯ
        }

        GameObject customer = customerPool[currentCustomerIndex];
        currentCustomerIndex = (currentCustomerIndex + 1) % customerPool.Count; // ���� ���� ���

        return customer;
    }

    // ���� Ȱ��ȭ�� �մ��� ���� ��ȯ�ϴ� �Լ�
    int GetActiveCustomerCount()
    {
        int count = 0;

        foreach (var customer in customerPool)
        {
            if (customer.activeSelf)
            {
                count++;
            }
        }

        return count;
    }
}
