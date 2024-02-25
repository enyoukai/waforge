using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wheat : MonoBehaviour
{
    Crop crop;
    int id;
    [SerializeField] Sprite seedSprite;
    [SerializeField] Sprite sprouteSprite;
    [SerializeField] Sprite[] wheatSprite;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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

    public void SetId(int id)
    {
        this.id = id;
    }

    void OnMouseDown()
    {
        if (crop.growthStage != GrowthStage.Mature)
        {
            return;
        }
        FarmManager.Instance.HarvestCrop(id);

        Vector3 particlePosition = new Vector3(transform.position.x, transform.position.y, -9.5f);
        Quaternion rotation = Quaternion.Euler(-90, 0, 0);

        Destroy(Instantiate(FarmRenderer.Instance.harvestParticles, particlePosition, rotation), 5);
        Destroy(gameObject);

    }
}
