using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HairColor { Blue, Green, Red }
public class ChangeHairColor : MonoBehaviour
{
    [SerializeField] HairColor color;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HairController hair = collision.gameObject.GetComponent<HairController>();
        if (hair == null) return;

        hair.ChangeHairColor(color);
    }
}
