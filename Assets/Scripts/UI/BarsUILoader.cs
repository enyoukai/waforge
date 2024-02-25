using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarsUILoader : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("BarsUI", LoadSceneMode.Additive);
    }
}
