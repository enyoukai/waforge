using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enum CropType for different types of crops

public class FarmManager : MonoBehaviour
{

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
        CropType type;
        GrowthStage growthStage;
        Vector2 position;

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
    Crop[] crops = new Crop[9];
    const float growthProbability = 0.5f;
    const float growthClockCheck = 20.0f;
    float growthClock = 0.0f;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
