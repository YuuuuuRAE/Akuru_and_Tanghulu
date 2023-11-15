using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingSpawner : MonoBehaviour
{
    public int index; // �� 1, �� -1 �ν����� â���� �����ϱ�
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

        // ������Ʈ Ǯ �ʱ�ȭ
        InitializeObjectPool();
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            // ������Ʈ Ǯ���� ���� ������ �մ� ��������
            GameObject customer = GetNextPassing();
            if (customer != null)
            {
                // Ȱ��ȭ ���·� ����� ��ġ, ȸ�� ����
                customer.SetActive(true);
                customer.transform.position = GetRandomSpawnPosition();
                customer.transform.rotation = transform.rotation;
            }

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    // ������Ʈ Ǯ �ʱ�ȭ
    void InitializeObjectPool()
    {
        passingPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int passingType = Random.Range(0, passingRange + 1); // ������ �մ� Ÿ�� ����
            GameObject passing = Instantiate(passingPrefab[passingType]);
            Passing passingScript = passing.GetComponent<Passing>();

            // Passing�� Ÿ�� ����
            passingScript.target = target;

            // Passing�� ������ ����
            passingScript.index = index;

            // ������ ��ġ ����
            Vector3 randomPosition = GetRandomSpawnPosition();
            passing.transform.position = randomPosition;

            // passingSpawner�� ȸ���� �����ϰ� ����
            passing.transform.rotation = transform.rotation;

            passing.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ ���·� ����
            passingPool.Add(passing);
        }
    }


    GameObject GetNextPassing()
    {
        if (passingPool.Count == 0)
        {
            return null; // Ǯ�� ��������� null ��ȯ
        }

        GameObject customer = passingPool[currentPassingIndex];
        currentPassingIndex = (currentPassingIndex + 1) % passingPool.Count; // ���� ���� ���

        return customer;
    }

    Vector3 GetRandomSpawnPosition()
    {
        // passingSpawner�� �ݶ��̴� ���� ������ ������ ��ġ ����
        float randomX = Random.Range(transform.position.x - transform.localScale.x / 2f, transform.position.x + transform.localScale.x / 2f);
        float randomY = Random.Range(transform.position.y - transform.localScale.y / 2f, transform.position.y + transform.localScale.y / 2f);
        float randomZ = transform.position.z;

        return new Vector3(randomX, randomY, randomZ);
    }
}
