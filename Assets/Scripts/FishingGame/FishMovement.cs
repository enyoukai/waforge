using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float minSpeed = 6f;
    float maxSpeed = 8f;
    float speed;

    void Awake()
    {
        int sign = Random.Range(0, 2) * 2 - 1;

        speed = Random.Range(minSpeed, maxSpeed) * sign;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FishWall"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, 0);
        }
    }

}
