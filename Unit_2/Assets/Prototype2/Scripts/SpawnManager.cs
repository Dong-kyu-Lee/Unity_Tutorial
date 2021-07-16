using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int randomDirection;

    private float spawnRangeX = 10f;
    private float spawnRangeZ = 10f;

    private float spawnPosX = 13f;
    private float spawnPosZ = 20f;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos;
        randomDirection = Random.Range(0, 3);
        if (randomDirection == 0)
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            animalPrefabs[animalIndex].transform.rotation = Quaternion.Euler(0, 180, 0);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
        else if(randomDirection == 1)
        {
            spawnPos = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            animalPrefabs[animalIndex].transform.rotation = Quaternion.Euler(0, 90, 0);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
        else if (randomDirection == 2)
        {
            spawnPos = new Vector3(spawnPosX, 0, Random.Range(0, spawnRangeZ));
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            animalPrefabs[animalIndex].transform.rotation = Quaternion.Euler(0,-90,0);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
