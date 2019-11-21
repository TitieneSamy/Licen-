using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Pausemenu : MonoBehaviour {

    public static bool Gameispaused = false;

    public GameObject pauseMenuUI;

    public string menu = "MainMenu";

    public SceneFader sceneFader;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gameispaused)
                Resume();
            else
                Pause();
        }
	}
   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Gameispaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Gameispaused = true;
    }
    public void Restart()
    {
        sceneFader.Fadeto(SceneManager.GetActiveScene().name);
        
        Time.timeScale = 1f;

    }
    public void Mainmenu()
    {
        sceneFader.Fadeto(menu);
        Time.timeScale = 1f;

       
    }
    public void Exit()
    {
        Application.Quit();
    }
}
