using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rb;
    float increaseSpeed = 0.25f;
    [SerializeField] GameObject particle;
    [SerializeField] AudioClip[] eat;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity *= 1 + increaseSpeed;
        Destroy(gameObject);
        RipplePostProcessor.instance.ShowEffect(GameManager.instance.Player.transform);
        PlaySnd();
    }

    private void PlaySnd()
    {
        int nr = Random.Range(0, eat.Length);
        AudioSource.PlayClipAtPoint(eat[nr], transform.position);
    }
}
