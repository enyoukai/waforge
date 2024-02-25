using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IslandButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 originalScale;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    [SerializeField] string scene;

    public void Teleport()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
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
