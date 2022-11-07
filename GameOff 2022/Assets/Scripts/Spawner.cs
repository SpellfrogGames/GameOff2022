using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject toSpawn;
    public GameObject[] objectsToSpawn;
    public Transform[] spawnPoints;

    public float baseSpawnInterval; //im dłużej trwa rozgrywka tym mniejszy interwał
    public float currentInterval;

    void Start()
    {
        toSpawn = objectsToSpawn[0];
        currentInterval = baseSpawnInterval;
        StartCoroutine(Spawn(currentInterval, toSpawn));
    }

    void DynamicInterval()
    {
        if(currentInterval > 0)
            currentInterval = (baseSpawnInterval - (GameplayManager.instance.timeElapsed / 50));
        else
            currentInterval = 0.5f; 
    }

    private IEnumerator Spawn(float interval, GameObject objectToSpawn)
    {
        yield return new WaitForSeconds(interval);

        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject spawnedObjectInstance = Instantiate(objectToSpawn, new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0.0f), Quaternion.identity);
        }

        DynamicInterval();
        StartCoroutine(Spawn(currentInterval, toSpawn));    
    }
}
