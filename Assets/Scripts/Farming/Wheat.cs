using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    Crop crop;
    [SerializeField] Sprite[] wheatSprite;
    public void SetCrop(Crop crop)
    {
        this.crop = crop;
    }
}
