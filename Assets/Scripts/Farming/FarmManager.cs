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

    public Crop(CropType type, Vector2 position)
    {
        this.type = type;
        this.position = position;
        growthStage = GrowthStage.Seed;
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
    Crop[] crops = new Crop[9];
    const float growthProbability = 0.5f;
    const float growthClockCheck = 20.0f;
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

            crops[i] = new Crop(cropType, new Vector2(i % 3, i / 3));
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


}
