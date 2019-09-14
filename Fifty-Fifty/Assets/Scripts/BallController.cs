using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 pressPosition;
    Vector2 endPosition;
    Vector2 direction;
    Rigidbody2D rb2d;

    [SerializeField] float forceFactor;
    [SerializeField] float maxForce;
    [SerializeField] float minForce;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endPosition = eventData.position;
        AddForce();
    }

    void AddForce()
    {
        direction = (pressPosition - endPosition).normalized;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        // rb2d.AddForce(direction * forceFactor);
        rb2d.velocity = direction* forceFactor;
    }
}
