using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWon : MonoBehaviour {

    public SceneFader sceneFader;
    public string nextlevel;
 
    private int leveltounlock=2;

    public void Nextlevel()
    {
        PlayerPrefs.SetInt("LevelReached", leveltounlock);
        sceneFader.Fadeto(nextlevel);
    }
    public void Mainmenu ()
    {
        sceneFader.Fadeto("MainMenu");
    }
  
	
	// Update is called once per frame
	void Update () {
		
	}
   
}
