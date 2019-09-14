using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    [SerializeField] GameObject greenHair;
    [SerializeField] GameObject blueHair;
    [SerializeField] GameObject redHair;
    GameObject currentHair;

    HairColor currentColor;


    private void Awake()
    {
        currentColor = HairColor.Green;
        currentHair = greenHair;
        DisableOldParticles(blueHair);
        DisableOldParticles(redHair);
    }

    public void ChangeHairColor(HairColor color)
    {
        if (currentColor == color) return;
        currentColor = color;

        DisableOldParticles(currentHair);

        if (color == HairColor.Blue)
            currentHair = blueHair;
        else if (color == HairColor.Green)
            currentHair = greenHair;
        else if (color == HairColor.Red)
            currentHair = redHair;

        EnableNewParticles(currentHair);
    }

    private void EnableNewParticles(GameObject holder)
    {
        ParticleSystem[] particles = holder.GetComponentsInChildren<ParticleSystem>();
        Array.ForEach(particles, p => p.enableEmission = true);
    }

    private void DisableOldParticles(GameObject holder)
    {
        ParticleSystem[] particles = holder.GetComponentsInChildren<ParticleSystem>();
        Array.ForEach(particles, p => p.enableEmission = false);
    }
}
