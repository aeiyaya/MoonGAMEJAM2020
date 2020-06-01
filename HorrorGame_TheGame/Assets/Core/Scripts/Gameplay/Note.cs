using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    public GameObject player;

    [TextArea()]
    public string desiredText;

    [Header("UI")]
    public Image note;
    public Text noteText;

    public Text interactiveText;

    bool pickedUp = false;

    public void PickUpNote()
    {
        if (!pickedUp)
        {
            pickedUp = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            Camera.main.GetComponent<MouseLook>().enabled = false;
            note.gameObject.SetActive(true);
            noteText.text = desiredText;
            interactiveText.text = "Press E to drop";
        }
        else
        {
            DropNote();
        }
    }
    public void DropNote()
    {
        if (pickedUp)
        {
            pickedUp = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            Camera.main.GetComponent<MouseLook>().enabled = true;
            interactiveText.text = "Press E to pick up";
            note.gameObject.SetActive(false);
        }
    }
}
