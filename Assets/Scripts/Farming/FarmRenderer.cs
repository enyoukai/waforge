using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmRenderer : MonoBehaviour
{
    public static FarmRenderer Instance;
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
    }

    public ParticleSystem harvestParticles;

    float zClosest = 9.0f;
    float zFurthest = 0.0f;
    public float clock;
    public const float rerenderClock = 2.0f;
    [SerializeField] GameObject wheatPrefab;
    [SerializeField] GameObject carrotPrefab;
    void Render()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Crop[] crops = FarmManager.Instance.GetCrops();

        for (int i = 0; i < crops.Length; i++)
        {
            if (crops[i] != null)
            {
                GameObject cropPrefab = null;
                switch (crops[i].type)
                {
                    case CropType.Wheat:
                        cropPrefab = wheatPrefab;
                        break;
                    case CropType.Carrot:
                        cropPrefab = carrotPrefab;
                        break;
                }

                GameObject crop = Instantiate(cropPrefab, new Vector3(crops[i].position.x, crops[i].position.y, 0), Quaternion.identity, gameObject.transform);


                float z = Mathf.Lerp(zFurthest, zClosest, (crops[i].position.y - FarmManager.Instance.yMin) / (FarmManager.Instance.yMax - FarmManager.Instance.yMin));

                crop.transform.position = new Vector3(crop.transform.position.x, crop.transform.position.y, z);

                switch (crops[i].type)
                {
                    case CropType.Wheat:
                        crop.GetComponent<Wheat>().SetCrop(crops[i]);
                        crop.GetComponent<Wheat>().SetId(crops[i].id);
                        break;
                    case CropType.Carrot:
                        crop.GetComponent<Carrot>().SetCrop(crops[i]);
                        crop.GetComponent<Carrot>().SetId(crops[i].id);
                        break;
                }
            }
        }
    }
    void Start()
    {
        Render();
    }

    void Update()
    {
        clock += Time.deltaTime;

        if (clock >= rerenderClock)
        {
            clock = 0;
            Render();
        }
    }
}
