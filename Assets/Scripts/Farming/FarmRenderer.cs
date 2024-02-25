using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmRenderer : MonoBehaviour
{
    [SerializeField] GameObject wheatPrefab;
    [SerializeField] GameObject carrotPrefab;
    void Start()
    {
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
                GameObject crop = Instantiate(cropPrefab, new Vector3(crops[i].position.x, crops[i].position.y, 0), Quaternion.identity);
            }
        }

    }

}
