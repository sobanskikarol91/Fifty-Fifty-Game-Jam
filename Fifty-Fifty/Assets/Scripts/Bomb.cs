using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rb;
    float increaseSpeed = 0.2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity *=  1 + increaseSpeed;
        Destroy(gameObject);
    }
}
