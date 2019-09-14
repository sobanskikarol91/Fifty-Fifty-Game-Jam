using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    [SerializeField] GameObject blueHair;
    [SerializeField] GameObject greenHair;
    [SerializeField] GameObject redHair;
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
        else if (color == HairColor.Red)
            currentHair = redHair;

        currentHair.SetActive(true);
    }
}
