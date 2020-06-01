using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    public Player playerCharacter;
    public Text interactiveText;

    public TweenRotation LeftDoor;
    public TweenRotation RightDoor;

    public AudioObject audioObject;
    public AudioClip doorOpeningSound;

    public bool IsLocked = false;
    public Conditions condition;
    public int amount = 3;

    public void OpenDoor()
    {
        if (IsLocked)
        {
            if (condition == Conditions.DemonSouls)
            {
                if (GameManager.Instance.DemonSoulsHarvested < amount)
                {
                    interactiveText.text = "You need " + amount + " Demon Souls to enter this door. You have " + GameManager.Instance.DemonSoulsHarvested + " currently.";
                    return;
                }
            }
        }
        GetComponent<BoxCollider>().enabled = false;

        LeftDoor.StartTween();
        RightDoor.StartTween();
        audioObject.PlaySoundEffect(doorOpeningSound);
    }

}
