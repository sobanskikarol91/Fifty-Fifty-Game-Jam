using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialJump : MonoBehaviour
{
    float speedJump = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speedJump;
    }
}
