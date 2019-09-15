using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    [SerializeField] GameObject greenHair;
    [SerializeField] GameObject blueHair;
    [SerializeField] GameObject redHair;

    [SerializeField] GameObject redPart;
    [SerializeField] GameObject bluePart;
    [SerializeField] GameObject greenPart;

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

    public void StopEmittingCurrentHairs()
    {
        DisableOldParticles(currentHair);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Col");
        Vector3 position = collision.contacts[0].point;
        GameObject prefab = bluePart;

        if (currentColor == HairColor.Blue)
            prefab = bluePart;
        else if (currentColor == HairColor.Red)
            prefab = redPart;
        else if (currentColor == HairColor.Green)
            prefab = greenPart;

        Instantiate(prefab, position, Quaternion.identity);
    }
}
