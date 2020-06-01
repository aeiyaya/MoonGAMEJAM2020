using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    // Trigger for monster monsterType
    public MonsterTypes monsterType;
    public GameObject monster;

    public Transform[] monsterSpawns;

    private void OnTriggerEnter(Collider other)
    {
        SpawnMonster();
        Debug.Log("Player Entered Trigger");
    }

    public void SpawnMonster()
    {
        if (!monster.activeInHierarchy)
            monster.SetActive(true);
    }
}


