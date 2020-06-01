using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    // Trigger for monster monsterType
    public MonsterTypes monsterType;
    public GameObject monster;

    public Transform[] monsterSpawns;


    public float monsterCooldown = 10f;
    private float lastTime = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (lastTime + monsterCooldown < Time.time)
        {
            lastTime = Time.time;
            SpawnMonster();

            Debug.Log("Player Entered Trigger");
        }
    }

    public void SpawnMonster()
    {
        if (monster != null)
        {
            if (!monster.activeInHierarchy)
                monster.SetActive(true);
        }
    }
}


