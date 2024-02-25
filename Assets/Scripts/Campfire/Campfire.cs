using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public static Campfire Instance;

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

    [SerializeField] Sprite rawFish;
    [SerializeField] Sprite cookedFish;
    [SerializeField] Sprite rawCarrot;
    [SerializeField] Sprite cookedCarrot;
    [SerializeField] SpriteRenderer carrotRenderer;
    [SerializeField] SpriteRenderer fishRenderer;

    public void PlaceFish()
    {
        fishRenderer.enabled = true;
        fishRenderer.sprite = rawFish;
    }

    public void PlaceCarrot()
    {
        carrotRenderer.enabled = true;
        carrotRenderer.sprite = rawCarrot;
    }

    public void CookCarrot()
    {
        carrotRenderer.sprite = cookedCarrot;
    }

    public void CookFish()
    {
        fishRenderer.sprite = cookedFish;
    }

    public void RemoveCarrot()
    {
        carrotRenderer.enabled = false;
    }

    public void RemoveFish()
    {
        fishRenderer.enabled = false;
    }
}
