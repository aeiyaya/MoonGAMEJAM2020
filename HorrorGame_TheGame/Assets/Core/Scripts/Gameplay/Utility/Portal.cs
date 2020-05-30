using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    [SerializeField] private string mapPortal = "Scenes/MainGame";

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(mapPortal);
    }

}
