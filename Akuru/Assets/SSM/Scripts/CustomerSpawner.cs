using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customers;
    public float spawnRateMin = 3f;
    public float spawnRateMax = 5f;

    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }


    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            int customerType = Random.Range(0, customers.Length);

            GameObject customer = Instantiate(customers[customerType], transform.position, transform.rotation);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
