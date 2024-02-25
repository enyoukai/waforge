using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    Crop crop;
    [SerializeField] Sprite[] carrotSprites;

    public void SetCrop(Crop crop)
    {
        this.crop = crop;
    }
}
