using System;
using UnityEngine;

public class EyesFallower : MonoBehaviour
{
    [SerializeField] float distance = 0.1f;
    [SerializeField] bool isAI;
    [SerializeField] bool isShooting;
    Action UpdateLookingDirection;

    private void Awake()
    {
        if (isAI)
            UpdateLookingDirection = LookingToPlayer;
        else 
            UpdateLookingDirection = LookingToMouse;

        if (isShooting)
            UpdateLookingDirection = LookingToShooting;
    }

    private void Update()
    {
        UpdateLookingDirection();
    }

    void LookingToMouse()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GameManager.instance.Player.position;
        transform.localPosition = direction.normalized * distance;
    }

    void LookingToPlayer()
    {
        Vector3 direction = GameManager.instance.Player.transform.position - transform.position;
        transform.localPosition = direction.normalized * distance;
    }

    void LookingToShooting()
    {
        Vector3 direction = GameManager.instance.Player.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localPosition = direction.normalized * distance;
    }
}