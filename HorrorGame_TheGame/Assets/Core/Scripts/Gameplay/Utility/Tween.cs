using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    public delegate void EndFunction();
    public EndFunction endFunction;

    public Vector3 StartPosition;
    public Vector3 EndPosition;

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
        transform.localPosition = StartPosition;
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
        Vector3 desiredPosition = reverse ? StartPosition : EndPosition;

        float elapsedTime = 0;

        while (elapsedTime < TweenTime)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, (elapsedTime / TweenTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        if (function != null)
            function();
        transform.localPosition = desiredPosition;
        StopTween();

        
    }

    public bool IsAnimating { get { return tween != null; } }

}
