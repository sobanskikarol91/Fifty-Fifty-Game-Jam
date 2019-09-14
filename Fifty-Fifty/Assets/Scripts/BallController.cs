using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    Vector2 startPress;
    Vector2 endPress;
    Vector2 direction;

    [SerializeField] AudioClip deathSnd;

    internal void Kill()
    {
        AudioSource.PlayClipAtPoint(deathSnd, transform.position);
       // gameObject.SetActive(false);
    }

    Rigidbody2D rb2d;

    [SerializeField] float forceFactor;
    [SerializeField] AudioClip jumpSnd;

    public static event Action OnMouseDown;
    public static event Action OnMouseUp;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);

        if (Input.GetMouseButtonDown(0))
            MouseDown();
        else if (Input.GetMouseButtonUp(0))
            MouseUp();
    }

    private void MouseDown()
    {
        startPress = Camera.main.WorldToScreenPoint(Input.mousePosition);
        OnMouseDown?.Invoke();
    }

    private void MouseUp()
    {
        OnMouseUp?.Invoke();
        endPress = Camera.main.WorldToScreenPoint(Input.mousePosition);
        AudioSource.PlayClipAtPoint(jumpSnd, transform.position);
        AddForce();
    }

    void AddForce()
    {
        direction = (startPress - endPress).normalized;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.velocity = direction * forceFactor;
    }
}