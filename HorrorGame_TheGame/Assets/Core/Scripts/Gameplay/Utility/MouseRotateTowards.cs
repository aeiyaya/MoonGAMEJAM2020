using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotateTowards : MonoBehaviour
{

    float depth = -10f;
    // Update is called once per frame
    void Update()
    {

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth));

    }
}
