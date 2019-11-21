using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public static bool Gameisover = false;
    public GameObject Gameoverui;

    public SceneFader sceneFader;

    
    public string menu = "MainMenu";

   

  
    private  void Gamefinish()
    {
       
        Time.timeScale = 0f;
        Gameisover = true;
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

        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
