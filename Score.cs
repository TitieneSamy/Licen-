using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text Scoretext;
    public PlayerStats playerStats;

    public void OnEnable()
    {
        StartCoroutine(AnimateText());
            }
    IEnumerator AnimateText()
    {

        Scoretext.text = "0";
        int score = 0;
        yield return new WaitForSeconds(.7f);

        while(score<playerStats.Scores())
        {
            score++;
            Scoretext.text = "Scor obtinut:" + "" + score.ToString();

            yield return new WaitForSeconds(.05f);

        }



    }

}
