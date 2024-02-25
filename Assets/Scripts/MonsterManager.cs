using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;

    public float protein = 1;
    public float grains = 1;
    public float fruits = 1;
    public float vegetables = 1;

    [SerializeField] float decrementMin = 0.01f;
    [SerializeField] float decrementMax = 0.05f;
    [SerializeField] float decrementClock = 10f;
    float time = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= decrementClock)
        {
            time = 0f;
            protein -= Random.Range(decrementMin, decrementMax);
            grains -= Random.Range(decrementMin, decrementMax);
            fruits -= Random.Range(decrementMin, decrementMax);
            vegetables -= Random.Range(decrementMin, decrementMax);

            if (protein < 0)
            {
                protein = 0;
            }
            if (grains < 0)
            {
                grains = 0;
            }
            if (fruits < 0)
            {
                fruits = 0;
            }
            if (vegetables < 0)
            {
                vegetables = 0;
            }
        }
    }

    public void AddProtein(float amt)
    {
        protein += amt;
        if (protein > 1)
        {
            protein = 1;
        }
    }


    public void AddGrains(float amt)
    {
        grains += amt;
        if (grains > 1)
        {
            grains = 1;
        }
    }

    public void AddFruits(float amt)
    {
        fruits += amt;
        if (fruits > 1)
        {
            fruits = 1;
        }
    }

    public void AddVegetables(float amt)
    {
        vegetables += amt;
        if (vegetables > 1)
        {
            vegetables = 1;
        }
    }

    public void SpawnHearts()
    {
        GameObject.Find("HeartParticles").GetComponent<ParticleSystem>().Play();
    }
}
