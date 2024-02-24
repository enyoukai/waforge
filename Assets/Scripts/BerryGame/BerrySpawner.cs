using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerrySpawner : MonoBehaviour
{
    public GameObject berryPrefab;
    float clock = 0f;
    float spawnTime = 2f;
    float spawnTimeMin = 1f;
    float spawnTimeMax = 3f;

    float ySpawn = 6f;
    float xLeftSpawn = -7.5f;
    float xRightSpawn = 7.5f;

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;

        if (clock >= spawnTime)
        {
            SpawnBerry();
            clock = 0;

            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
        }
    }

    void SpawnBerry()
    {
        float xSpawn = Random.Range(xLeftSpawn, xRightSpawn);

        Instantiate(berryPrefab, new Vector2(xSpawn, ySpawn), Quaternion.identity);
    }
}
