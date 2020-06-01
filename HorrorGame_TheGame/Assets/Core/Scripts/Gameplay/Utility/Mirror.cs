using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Player player;
    public Light lightReflection;
    public bool IsOut { get { return isActiveAndEnabled; } }
    [SerializeField] private Tween tween = null;

    public void TakeOutMirror()
    {
        if (tween.IsAnimating)
            return;

        gameObject.SetActive(true);
        tween.StartTween(false);
    }
    public void PutAwayMirror()
    {
        if (tween.IsAnimating)
            return;

        tween.endFunction = ChangeActive;
        tween.StartTween(true, tween.endFunction);
    }

    // Activates after Tween Ends
    public void ChangeActive()
    {
        if (isActiveAndEnabled)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }

    public void UpdateLight()
    {
        if (player.ActiveLightOn)
        {
            lightReflection.enabled = true;
            lightReflection.intensity = player.ActiveLight.intensity;
        }
        else
        {
            lightReflection.enabled = false;
        }
    }
}
