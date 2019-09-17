using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewfinder : MonoBehaviour
{
    [SerializeField] GameObject arrow;

    private void Awake()
    {
        BallController.OnDragging += Rotate;
        BallController.OnMouseDown += () => arrow.SetActive(true);
        BallController.OnMouseUp += () => arrow.SetActive(false);
    }

    private void Rotate()
    {
        Vector2 start = BallController.startPress;
        Vector2 end = Input.mousePosition;

        //float angle = Vector2.Angle(start, end);
        //Debug.Log(BallController.startPress + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition) + " "  +angle);
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //float newAngle = Mathf.Sign(Vector3.Cross(start, end).z) < 0 ? (360 - angle) % 360 : angle;
        //transform.rotation  =  Quaternion.Euler(new Vector3(0,0,newAngle));
        float angle  = Quaternion.FromToRotation(Vector3.right,   start - end).eulerAngles.z;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Debug.Log(angle);
    }

    private void OnDisable()
    {
        BallController.OnMouseDown -= () => arrow.SetActive(true);
        BallController.OnMouseUp -= () => arrow.SetActive(false);
        BallController.OnDragging -= Rotate;
    }
}
