using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterTypes monsterType;

    public AudioClip appearSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioClip movementSound;

    public AudioObject audioObject;

    public int maxHealth;
    private int currentHealth;

    public int damage = 50;

    private void Start()
    {
        audioObject = GetComponent<AudioObject>();
    }

    private void OnEnable()
    {
        Debug.Log("PLAY APPEAR SOUND");
        audioObject.PlaySoundEffect(appearSound);
    }

    public void DealDamage()
    {
        GameManager.Instance.player.TakeDamage(damage);
    }
    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
            return true;
        }
        audioObject.PlaySoundEffect(hurtSound);
        return false;
    }
    public void Death()
    {

        StartCoroutine(MonsterDeath());
    }

    IEnumerator MonsterDeath()
    {
        // Play Sound

        audioObject.PlaySoundEffect(deathSound);
        yield return new WaitForSeconds(1);
        // Give Souls
        GameManager.Instance.DemonSoulsHarvested++;
        // Destroy
        Destroy(this.gameObject);
    }


    public bool Spawned { get { return isActiveAndEnabled; } }
}

public enum MonsterTypes
{
    Charger,
    Shadow,
    Stalker
}