using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float fallSpeed = 5f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2(0, -fallSpeed);
    }

}
