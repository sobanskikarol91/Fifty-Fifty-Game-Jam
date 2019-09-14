using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;

    void Update()
    {
        transform.Rotate(new Vector3(0,0,1) * speed);    
    }
}
