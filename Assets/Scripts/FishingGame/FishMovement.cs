using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float minSpeed = 4f;
    float maxSpeed = 6f;
    float speed;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int sign = Random.Range(0, 2) * 2 - 1;

        if (sign < 0)
        {
            spriteRenderer.flipX = true;
        }

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
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

}
