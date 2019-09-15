using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HairColor { Blue = 0, Green = 1, Red = 2 }
public class ChangeHairColor : MonoBehaviour
{
    [SerializeField] HairColor color;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.desireColor != color)
            GameManager.instance.WrongColor();
        else
        {
            HairController hair = collision.gameObject.GetComponent<HairController>();
            if (hair == null) return;

            hair.ChangeHairColor(color);
            GameManager.instance.AddScore();
        }
    }
}
