using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Image draggableImage = null;
    int index;
    InventoryItem item;

    public void SetItem(InventoryItem item)
    {
        this.item = item;
    }

    public void SetIndex(int index)
    {
        this.index = index;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Image>().enabled = false;

        draggableImage = Instantiate(InventoryRenderer.Instance.draggableImage, transform);

        draggableImage.sprite = GetComponent<Image>().sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggableImage.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(draggableImage.gameObject);
        Inventory.RemoveItem(index);

        int countLoaded = SceneManager.sceneCount;

        for (int i = 0; i < countLoaded; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name == "Forest")
            {
                FeedMonster();
            }
        }
    }

    void FeedMonster()
    {
        MonsterManager.Instance.AddProtein(0.2f);
        MonsterManager.Instance.SpawnHearts();
    }

    void CookFish()
    {
        Debug.Log("Cooking Fish");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
