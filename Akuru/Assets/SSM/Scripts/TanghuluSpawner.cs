using System.Collections.Generic;
using UnityEngine;

public class TanghuluSpawner : MonoBehaviour
{
    // ���ķ� �����忡 ����
    // ���ķ� ����
    public GameObject[] tanghulus;
    // ���ķ簡 ���� �� ������
    public Transform[] stand;
    // �������� ����ִ��� üũ
    public GameObject[] purchase;
    // �������� �ѹ�
    public int standNum;

    int activeStandCount = 0;

    HashSet<Vector3> spawnedLocations = new HashSet<Vector3>();

    void Update() // �� �κ��� ��ǻ� �ӽ�(������ ��Ʈ�� �����ؾ���)
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

                // �̹� ������ ��ġ���� Ȯ��
                if (!spawnedLocations.Contains(spawnPosition))
                {
                    int tanghuluType = Random.Range(0, tanghulus.Length);
                    GameObject tanghulu = Instantiate(tanghulus[tanghuluType], spawnPosition, Quaternion.identity);

                    // ������ ��ġ�� ���
                    spawnedLocations.Add(spawnPosition);
                }
            }
        }
    }
}