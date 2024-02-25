using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 originalScale = new Vector3(1, 4, 1);
    [SerializeField] GameObject map;
    public void RenderMap()
    {
        map.SetActive(true);

        GameObject bars = GameObject.Find("BarsParent");
        if (bars != null)
        {
            bars.SetActive(false);
        }
    }

    public void CloseMap()
    {
        map.SetActive(false);

        GameObject bars = GameObject.Find("BarsParent");
        if (bars != null)
        {
            bars.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMap();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        transform.localScale = originalScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
        transform.localScale = originalScale;
    }
}
