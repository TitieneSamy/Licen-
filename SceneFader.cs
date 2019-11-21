using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
     StartCoroutine(Fadein());
    }
    public void Fadeto(string scene)
    {
        StartCoroutine(Fadeout(scene));
    }

    IEnumerator Fadein()
    {
        float t = 1f;
       
        while(t>0f)
        {
            t -= Time.deltaTime ;
            float a = curve.Evaluate(t);
            img.color = new Color(0f,0f,0f,a);
            yield return 0;
        }      

    }
    IEnumerator Fadeout(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        //Load a scene
        SceneManager.LoadScene(scene);
    }
}
