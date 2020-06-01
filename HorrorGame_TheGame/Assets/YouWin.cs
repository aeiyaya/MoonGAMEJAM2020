using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{
    public Image YouWinScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            YouWinScreen.gameObject.SetActive(true);
        }
    }
}
