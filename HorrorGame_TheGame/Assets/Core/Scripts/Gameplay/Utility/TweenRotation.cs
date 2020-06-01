using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRotation : MonoBehaviour
{
    public delegate void EndFunction();
    public EndFunction endFunction;

    public float StartAngle;
    public float EndAngle;

    public Vector3 angles;

    public float TweenTime = 1f;

    private void Awake()
    {
        SetToStart();
    }
    private void OnEnable()
    {
        SetToStart();
    }
    private void OnDisable()
    {
        SetToStart();   
    }

    public void SetToStart()
    {
        transform.localRotation = Quaternion.Euler(angles * StartAngle);
    }

    Coroutine tween;
    public void StartTween(bool reverse = false, EndFunction function = null)
    {
        if (tween != null)
            StopCoroutine(tween);
        tween = null;
        
        tween = StartCoroutine(DoTween(reverse, function));

    }
    public void StopTween()
    {
        if (tween == null)
            return;
        StopCoroutine(tween);
        tween = null;
    }
    
    IEnumerator DoTween(bool reverse, EndFunction function = null)
    {
        Quaternion desiredRotation = reverse ? Quaternion.Euler(angles * StartAngle) : Quaternion.Euler(angles * EndAngle);

        float elapsedTime = 0;

        while (elapsedTime < TweenTime)
        {

            transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotation, (elapsedTime / TweenTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        if (function != null)
            function();

        transform.localRotation = desiredRotation;
        StopTween();

        
    }

    public bool IsAnimating { get { return tween != null; } }
}
