using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BarsRenderer : MonoBehaviour
{
    [SerializeField] Slider grainsSlider;
    [SerializeField] Slider fruitsSlider;
    [SerializeField] Slider vegetablesSlider;
    [SerializeField] Slider proteinSlider;

    void Update()
    {
        grainsSlider.value = MonsterManager.Instance.grains;
        fruitsSlider.value = MonsterManager.Instance.fruits;
        vegetablesSlider.value = MonsterManager.Instance.vegetables;
        proteinSlider.value = MonsterManager.Instance.protein;
    }

}
