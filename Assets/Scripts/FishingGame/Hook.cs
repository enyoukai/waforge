using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] FishingRod fishingRod;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fish")
        {
            StartCoroutine(fishingRod.CatchFish());
            Destroy(other.gameObject);
        }
    }
}
