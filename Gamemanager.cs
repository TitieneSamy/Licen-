using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject gameoverUI;
    public static bool Gameisover ;

    public GameObject levelWon;
    
    private void Start()
    {
        Gameisover = false;
        levelWon.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if (PlayerStats.Lives <= 0)
        {
     
            Endgame();
        }
        if (Gameisover)
        return;
    }
    void Endgame()
    {
        Gameisover = true;

        gameoverUI.SetActive(true);
        
    }
    public void Levelwon()
    {
        Gameisover = true;
     
levelWon.SetActive(true);

        FindObjectOfType<PlayerStats>().Scores();
    }
    
          
        
}
