using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public string weaponType;

    public void PickupWeapon()
    {
        bool foundWeapon = false;
        switch(weaponType)
        {
            case "Lamp":
                GameManager.Instance.hasLamp = true;
                foundWeapon = true;
                break;
            case "Flashlight":
                GameManager.Instance.hasFlashlight = true;
                foundWeapon = true;
                break;
            case "Mirror":
                GameManager.Instance.hasMirror = true;
                foundWeapon = true;
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
