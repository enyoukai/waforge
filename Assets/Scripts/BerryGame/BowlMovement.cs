using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 8f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Berry"))
        {
            Destroy(other.gameObject);
            Inventory.Berries++;
        }

    }

}
