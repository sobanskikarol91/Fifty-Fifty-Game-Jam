using System;
using UnityEngine;

public class EyesFallower : MonoBehaviour
{
    [SerializeField] float distance = 0.1f;
    [SerializeField] bool isAI;

    Action GetDirection;

    private void Awake()
    {
        GetDirection = LookingToMouse;
    }

    private void Update()
    {
        LookingToMouse();
    }

    void LookingToMouse()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GameManager.instance.Player.position;
        transform.localPosition = direction.normalized * distance;
    }
}