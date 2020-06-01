using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponPickup : MonoBehaviour
{
    public Text mirrorText;
    public Text lampText;
    public Text flashlightText;
    public string weaponType;

    public void PickupWeapon()
    {
        bool foundWeapon = false;
        switch(weaponType)
        {
            case "Lamp":
                GameManager.Instance.hasLamp = true;
                foundWeapon = true;
                lampText.gameObject.SetActive(true);
                break;
            case "Flashlight":
                GameManager.Instance.hasFlashlight = true;
                foundWeapon = true;
                flashlightText.gameObject.SetActive(true);
                break;
            case "Mirror":
                GameManager.Instance.hasMirror = true;
                foundWeapon = true;
                mirrorText.gameObject.SetActive(true);
                break;
            default:
                Debug.Log(weaponType + ": wasn't found");
                break;
        }

        if (foundWeapon)
        {
            Destroy(this.gameObject);
        }
        
    }
}
