using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public GameObject player;
    public float spawnDistance = 2f;
    Vector3 spawnLocation;

    public Monster monster;
    public float speed = 3f;

    private void OnEnable()
    {
        spawnLocation = player.transform.position;
        appeared = false;
    }
    bool appeared = false;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, spawnLocation) > spawnDistance)
        {
            if (!appeared)
            {
                monster.Appear();
                transform.position = spawnLocation;
                appeared = true;
            }
        }
        if (appeared)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<Player>().TakeDamage(monster.damage);
            Debug.Log("This worked");
            this.gameObject.SetActive(false);
        }
    }
}
