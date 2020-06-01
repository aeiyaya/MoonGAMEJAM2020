using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon : MonoBehaviour
{
    public int damage;
    public float lightRange;


    // Update is called once per frame
    void Update()
    {

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * lightRange);
    }
}
