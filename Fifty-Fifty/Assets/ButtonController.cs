using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public AudioClip high;
    public AudioClip press;

    public void Highlighted()
    {
        AudioSource.PlayClipAtPoint(high, transform.position);
    }

    public void PressAudio()
    {
        AudioSource.PlayClipAtPoint(press, transform.position);
    }
}
