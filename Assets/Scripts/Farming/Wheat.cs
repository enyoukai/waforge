using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    Crop crop;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite seedSprite;
    [SerializeField] Sprite sprouteSprite;
    [SerializeField] Sprite[] wheatSprite;
    public void SetCrop(Crop crop)
    {
        this.crop = crop;

        if (crop.growthStage == GrowthStage.Seed)
        {
            spriteRenderer.sprite = seedSprite;
        }
        else if (crop.growthStage == GrowthStage.Sprout)
        {
            spriteRenderer.sprite = sprouteSprite;
        }
        else if (crop.growthStage == GrowthStage.Mature)
        {
            spriteRenderer.sprite = wheatSprite[Random.Range(0, wheatSprite.Length)];
        }
    }
}
