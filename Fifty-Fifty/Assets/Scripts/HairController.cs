using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    [SerializeField] GameObject greenHair;
    [SerializeField] GameObject blueHair;
    [SerializeField] GameObject redHair;

    ParticleSystem[] particles;
    GameObject currentHair;
    Rigidbody2D rb2d;
    HairColor currentColor;
    private Vector2 originalSpeed;
    private float orginalLifeTime;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalSpeed = rb2d.velocity;
        currentColor = HairColor.Green;
        currentHair = greenHair;
        DisableOldParticles(blueHair);
        DisableOldParticles(redHair);
        orginalLifeTime = 100;
    }

    private void Update()
    {
       // float percantage = rb2d.velocity.magnitude / originalSpeed.magnitude;
       // Array.ForEach(particles, p => p.startLifetime = orginalLifeTime * percantage);
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
        particles = holder.GetComponentsInChildren<ParticleSystem>();
        Array.ForEach(particles, p => p.enableEmission = true);
    }

    private void DisableOldParticles(GameObject holder)
    {
        particles = holder.GetComponentsInChildren<ParticleSystem>();
        Array.ForEach(particles, p => p.enableEmission = false);
    }
}
