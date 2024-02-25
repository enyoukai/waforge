using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    Crop crop;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite seedSprite;
    [SerializeField] Sprite sprouteSprite;
    [SerializeField] Sprite[] carrotSprites;

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
            spriteRenderer.sprite = carrotSprites[Random.Range(0, carrotSprites.Length)];
        }
    }
}
