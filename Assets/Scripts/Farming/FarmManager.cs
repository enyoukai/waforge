using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CropType
{
    Wheat,
    Carrot,
}

public enum GrowthStage
{
    Seed,
    Sprout,
    Mature,
}
public class Crop
{
    public CropType type;
    public GrowthStage growthStage;
    public Vector2 position;
    public int id;

    public Crop(CropType type, Vector2 position, int id)
    {
        this.type = type;
        this.position = position;
        growthStage = GrowthStage.Seed;
        this.id = id;
    }

    public void Grow()
    {
        if (growthStage == GrowthStage.Seed)
        {
            growthStage = GrowthStage.Sprout;
        }
        else if (growthStage == GrowthStage.Sprout)
        {
            growthStage = GrowthStage.Mature;
        }
    }
}

public class FarmManager : MonoBehaviour
{
    public static FarmManager Instance;
    float xMin = -7.75f;
    float xMax = 7.75f;
    public float yMin = -4;
    public float yMax = -1;
    Crop[] crops = new Crop[9];
    [SerializeField] float growthProbability = 0.5f;
    [SerializeField] float growthClockCheck = 20.0f;
    float growthClock = 0.0f;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < crops.Length; i++)
        {
            // initialize cropType to random enum
            CropType cropType = (CropType)Random.Range(0, 2);

            crops[i] = new Crop(cropType, new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)), i);
        }
    }

    public Crop[] GetCrops()
    {
        return crops;
    }

    void Update()
    {
        growthClock += Time.deltaTime;

        if (growthClock >= growthClockCheck)
        {
            growthClock = 0;
            for (int i = 0; i < crops.Length; i++)
            {
                if (crops[i] != null)
                {
                    float roll = Random.Range(0.0f, 1.0f);
                    if (roll <= growthProbability)
                    {
                        crops[i].Grow();
                    }
                }
            }
        }
    }

    public void HarvestCrop(int index)
    {
        // CHECK TYPE OF CROP, ADD TO INVENTORY
        switch (crops[index].type)
        {
            case CropType.Wheat:
                Inventory.Wheat++;
                break;
            case CropType.Carrot:
                Inventory.Carrots++;
                break;
        }

        crops[index] = new Crop((CropType)Random.Range(0, 2), new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)), index);
    }


}
