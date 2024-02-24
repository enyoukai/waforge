using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlMovement : MonoBehaviour
{
    Rigidbody2D rb;
    PolygonCollider2D pc;
    float speed = 8f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, 0);
    }


    void Update()
    {
        Debug.Log("Berries: " + Inventory.Berries);
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
