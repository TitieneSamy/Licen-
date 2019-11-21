using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class Mainmenu : MonoBehaviour {



    public SceneFader sceneFader;


    public void PlayGame(string LevelSelect)
    {
        sceneFader.Fadeto(LevelSelect);
            }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    private void OnMouseEnter()
    {
        FindObjectOfType<AudioManager>().Play("MainMenubuttons");

    }

}
