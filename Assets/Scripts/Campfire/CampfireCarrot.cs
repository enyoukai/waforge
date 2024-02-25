using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireCarrot : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Campfire.Instance == null)
        {
            return;
        }

        Campfire.Instance.RemoveCarrot();
    }
}
