using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewfinder : MonoBehaviour
{
    [SerializeField] GameObject arrow;

    private void Start()
    {
        BallController.OnDragging += Rotate;
        BallController.OnMouseDown += ActiveArrow;
        BallController.OnMouseUp +=  DeactiveArrow;
    }

    void ActiveArrow()
    {
        Rotate();
        arrow.SetActive(true);
    }

    void DeactiveArrow()
    {
        arrow.SetActive(false);
    }

    private void Rotate()
    {
        Vector2 start = BallController.startPress;
        Vector2 end = Input.mousePosition;


        float angle  = Quaternion.FromToRotation(Vector3.right,   start - end).eulerAngles.z;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnDisable()
    {
        BallController.OnMouseDown -= ActiveArrow;
        BallController.OnMouseUp -= DeactiveArrow;
        BallController.OnDragging -= Rotate;
    }
}
