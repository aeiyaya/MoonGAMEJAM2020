using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public Player player;

    // Weapons player can use
    public bool hasLamp = false;
    public bool hasFlashlight = false;
    public bool hasMirror = false;
    
    // Current map
    private string currentMap;

    public int DemonSoulsHarvested = 0;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;

        if (_instance != null && _instance!= this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }


    public void GameOver()
    {

    }
    public void ResetStage()
    {
        
    }

    public void CheckPoint()
    {
        // When a player reaches a checkpoint save the player stats as well as 
    }
}

public enum Conditions
{
    None,
    DemonSouls
}
