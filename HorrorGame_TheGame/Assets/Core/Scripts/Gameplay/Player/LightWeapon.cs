using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon : MonoBehaviour
{
    public int damage;
    public float lightRange;
    public float damageCooldown = 1f;

    public LayerMask enemyLayer;

    string lastTag;
    float nextDamageTime = 0;
    // Update is called once per frame
    void Update()
    {
        Collider[] inter = Physics.OverlapSphere(Camera.main.transform.position + Camera.main.transform.forward * lightRange, 2f, enemyLayer);
        if (inter.Length > 0 && lastTag != inter[0].tag)
        {
            lastTag = inter[0].tag;
            nextDamageTime = Time.time + damageCooldown;
            DealDamage(inter[0].gameObject);
        }
        if (nextDamageTime < Time.time)
        {
            lastTag = null;
        }
    }

    public void DealDamage(GameObject mon)
    {
        mon.GetComponent<Monster>().TakeDamage(damage);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * lightRange);
    }
}
