using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireFish : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Campfire.Instance == null)
        {
            return;
        }

        Campfire.Instance.RemoveFish();
    }
}
