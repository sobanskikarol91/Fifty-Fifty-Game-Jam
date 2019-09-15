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
    Animator animator;
    Rigidbody2D rb2d;
    HairController hair;
    bool isAlive = true;
    [SerializeField] AudioClip deathSnd;
    [SerializeField] float forceFactor;
    [SerializeField] AudioClip jumpSnd;
    [SerializeField] AudioClip bounce;


    public static event Action OnMouseDown;
    public static event Action OnMouseUp;
    public static event Action OnDragging;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        hair = GetComponent<HairController>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        if (!isAlive) return;


        if (Input.GetMouseButtonDown(0))
            MouseDown();
        else if (Input.GetMouseButtonUp(0))
            MouseUp();
        else if (Input.GetMouseButton(0))
            GameManager.instance.DecreaseTimeSlow();
            

    }

    internal void Kill()
    {
        AudioSource.PlayClipAtPoint(deathSnd, transform.position);
        MonoBevahiourExtension.StartLerp(this, rb2d.velocity, Vector3.zero, 0.3f, () => rb2d.bodyType = RigidbodyType2D.Static, (x) => rb2d.velocity = x);
        hair.StopEmittingCurrentHairs();
        animator.SetTrigger("death");
        isAlive = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("bounce");
        AudioSource.PlayClipAtPoint(bounce, transform.position);
    }
}