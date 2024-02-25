using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BerrySpawner : MonoBehaviour
{
    [SerializeField] List<Sprite> berrySprites;
    public GameObject berryPrefab;
    float clock = 0f;
    float spawnTime = 2f;
    float spawnTimeMin = 0.5f;
    float spawnTimeMax = 2f;

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

        SpriteRenderer spriteRenderer = Instantiate(berryPrefab, new Vector2(xSpawn, ySpawn), Quaternion.identity).GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = berrySprites[Random.Range(0, berrySprites.Count)];
    }

    public void BerryFell()
    {
    }
}
