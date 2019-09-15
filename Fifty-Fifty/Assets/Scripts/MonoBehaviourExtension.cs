using System;
using System.Collections;
using UnityEngine;

public static class MonoBevahiourExtension
{
    public static Coroutine StartLerp(this MonoBehaviour target, float origin, float destination, float duration, Action OnComplete = null, Action<float> OnExecuting = null)
    {
       return target.StartCoroutine(Lerp(origin, destination, duration, OnComplete, OnExecuting));
    }

    static IEnumerator Lerp(float currentValue, float destination, float duration, Action OnComplete = null, Action<float> OnExecuting = null)
    {
        float startTime = Time.time;
        float startValue = currentValue;

        while (true)
        {
            float percantage = (Time.time - startTime) / duration;
            currentValue = Mathf.Lerp(startValue, destination, percantage);

            OnExecuting?.Invoke(currentValue);
            if (percantage >= 1)
                break;

            yield return null;
        }

        OnComplete?.Invoke();
    }

    public static void StartLerp(this MonoBehaviour target, Vector3 origin, Vector3 destination, float duration, Action OnComplete = null, Action<Vector3> OnExecuting = null)
    {
        target.StartCoroutine(Lerp(origin, destination, duration, OnComplete, OnExecuting));
    }

    static IEnumerator Lerp(Vector3 currentValue, Vector3 destination, float duration, Action OnComplete = null, Action<Vector3> OnExecuting = null)
    {
        float startTime = Time.time;
        Vector3 startValue = currentValue;

        while (true)
        {
            float percantage = (Time.time - startTime) / duration;
            currentValue = Vector3.Lerp(startValue, destination, percantage);

            OnExecuting?.Invoke(currentValue);
            if (percantage >= 1)
                break;

            yield return null;
        }

        OnComplete?.Invoke();
    }

    public static void PingPongLerp(this MonoBehaviour target, Vector3 origin, Vector3 offset, float duration, Action OnComplete = null, Action<Vector3> OnExecuting = null)
    {
        target.StartCoroutine(IEPingPongLerp(target, origin, offset, duration, OnComplete, OnExecuting));
    }

    static IEnumerator IEPingPongLerp(this MonoBehaviour target, Vector3 currentValue, Vector3 offset, float duration, Action OnComplete = null, Action<Vector3> OnExecuting = null)
    {
        Vector3 destination = currentValue - offset;
        float time = duration / 2;
        Func<IEnumerator> Ping = () => Lerp(currentValue, destination, time, OnComplete, OnExecuting);
        Func<IEnumerator> Pong = () => Lerp(destination, currentValue, time, OnComplete, OnExecuting);

        yield return target.StartCoroutine(Ping());
        yield return target.StartCoroutine(Pong());
    }
}