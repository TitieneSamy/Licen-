using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Leveloader : MonoBehaviour
{
    //am declarat ecranul de încărcare
    public GameObject loadingscreen;
    //am declarat Slider-ul
    public Slider slider;
    //Am declarat progresul
    public Text progresstext;
    //am creat funcția principală care nu întoarce nimic fiind publică
    public void Loadlevel(string sceneIndex)
    {//Încarc nivelul 
        StartCoroutine(LoadAsyncronosly(sceneIndex));
    }//Am creat funcția efectivă care se ocupă cu încărcarea nivelului 
    IEnumerator LoadAsyncronosly(string sceneIndex)
    {//Am încărcat scena
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex);
        //am activat ecranul de încărcare
        loadingscreen.SetActive(true);
       //aici aștept cât timp se-ncarcă nivelul
        while (!async.isDone)


        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progress;
            progresstext.text = progress * 100 +"%";
            yield return null;

        }
    }

}

