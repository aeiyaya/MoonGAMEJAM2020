using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    [Header("Game Objects")]
    public Mirror mirror;
    public GameObject Lamp;
    public GameObject Flashlight;

    private GameObject[] lightWeapons;

    private GameObject activeWeapon;
    private Light activeLight;
    private Light mirrorLight;


    [Header("Stats")]
    // Maximum values they can be set to
    [SerializeField] private int maxHealth;             // Max HP
    [SerializeField] private int maxBatteryLevel;       // Max Battery Energy
    [SerializeField] private int maxFlashlightPower;    // Max Amount of Light flashlight can output


    [Header("Utility Controls")]
    [SerializeField] private float damageCooldown = 1f; // Amount of time before damage can be taken again (seconds)
    private float timeDamageTaken = 0f;

    [SerializeField] private Vector3 interactiveCenterPosition = Vector3.zero;
    [SerializeField] private float interactiveRange = 1f;
    [SerializeField] private float interactiveMaxAngle = 40f;
    [SerializeField] private LayerMask interactiveLayer = 0;

    [SerializeField] private float scrollScale = 3f;


    [Header("UI")]
    public Text interactiveText;

    private int currentHealth;
    private int currentBatteryLevel;
    private int currentFlashlightPower;

    public int CurrentHealth { get { return currentHealth; } }
    public int CurrentBatterLevel { get { return currentBatteryLevel; } }
    public int CurrentFlashlightPower { get { return currentFlashlightPower; } set { currentFlashlightPower = value; } }

    public Light ActiveLight { get { return activeLight; } }
    public bool ActiveLightOn { get { return activeLight.isActiveAndEnabled; } }


    private GameObject heldWeapon;

    [Header("Sounds")]
    AudioObject audioObject;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioClip dieDemon;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        lightWeapons = new GameObject[] { Lamp, Flashlight};
        for (int i = 0; i < lightWeapons.Length; i++)
        {
            lightWeapons[i].SetActive(false);
        }

        audioObject = GetComponent<AudioObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Interact
        Interactive();

        // Inputs
        // Mirror
        
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Q) && gameManager.hasMirror)
            {
                MirrorToggle();
            }
            //Weapons
            //Lamp
            if (Input.GetKeyDown(KeyCode.Alpha1) && gameManager.hasLamp)
                TakeOutWeapon(0);
            //Flashlight
            if (Input.GetKeyDown(KeyCode.Alpha2) && gameManager.hasFlashlight)
                TakeOutWeapon(1);
        }
    }
    void PlayerInput()
    {

    }
    string lastTag;

    void Interactive()
    {
        Collider[] inter = Physics.OverlapSphere(Camera.main.transform.position + Camera.main.transform.forward * interactiveCenterPosition.z, interactiveRange, interactiveLayer);

        if (inter.Length > 0)
        {
            if (inter[0].tag != lastTag)
            {
                interactiveText.enabled = true;
                lastTag = inter[0].tag;
                switch(inter[0].tag)
                {
                    case "Door":
                        interactiveText.text = "Press E to open door";
                        break;
                    case "Pickup":
                        interactiveText.text = "Press E to pick up";
                        break;
                }
            }

            // Interact if button is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact(inter[0]);
            }
        }
        else
        {
            if (interactiveText.enabled)
            {
                lastTag = null;
                interactiveText.enabled = false;
            }
        }
    }
    
    void Interact(Collider interObject)
    {
        interObject.GetComponent<Interactable>().Interact();
    }

    // Mirror seperate from weapons
    private void MirrorToggle()
    {
        if (!mirror.IsOut)
            mirror.TakeOutMirror();
        else
            mirror.PutAwayMirror();
    }
    

    ///////////////////////////////////
    ///////// LIGHT WEAPONS ///////////
    /////////////////////////////////// 
    
    public void TakeOutWeapon(int i)
    {
        if (i >= 0 && i < lightWeapons.Length)
        {
            if (activeWeapon != lightWeapons[i])
            {
                if (activeWeapon != null)
                    activeWeapon.SetActive(false);
                activeWeapon = lightWeapons[i];
                activeWeapon.SetActive(true);
            }
            else
            {
                if (activeWeapon != null) {
                    activeWeapon.SetActive(false);
                    activeWeapon = null;
                }
            }
        }
    }

    public void ToggleLight()
    {
        activeLight.enabled = !activeLight.enabled;

        mirror.UpdateLight();
    }

    public void ControlLightPower()
    {

    }
    ///////////////////////////////////
    //////////// DAMAGE ///////////////
    /////////////////////////////////// 
    public void TakeDamage(int amount)
    {
        // Damage cooldown
        if (timeDamageTaken + damageCooldown > Time.time)
        {
            audioObject.PlaySoundEffect(hurtSound);

            // Reset Time damage taken
            timeDamageTaken = Time.time;
            currentHealth -= amount;
            if (currentHealth > 0)
                return;
            currentHealth = 0;
            GameOver();
        }
    }

    public void DealDamage(Monster monster, int amount)
    {
        
    }

    public void GameOver()
    {
        if (CurrentHealth <= 0)
            gameManager.GameOver();
    }

    /////////////////////
    //// INTERACTIVE ////
    /////////////////////

    public void EnterDoor()
    {

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position + interactiveCenterPosition, interactiveRange);

        Gizmos.DrawWireSphere(Camera.main.transform.position + Camera.main.transform.forward * interactiveCenterPosition.z, interactiveRange);

    }
}
