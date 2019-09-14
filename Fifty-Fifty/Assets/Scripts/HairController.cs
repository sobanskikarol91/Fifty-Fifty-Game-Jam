using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    [SerializeField] GameObject blueHair;
    [SerializeField] GameObject greenHair;

    GameObject currentHair;

    private void Awake()
    {
        currentHair = greenHair;
    }

    public void ChangeHairColor(HairColor color)
    {
        currentHair.SetActive(false);

        if (color == HairColor.Blue)
            currentHair = blueHair;
        else if (color == HairColor.Green)
            currentHair = greenHair;

        currentHair.SetActive(true);
    }
}
