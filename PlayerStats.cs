using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startmoney = 500;
    public static int Lives;
    public int startLives = 5;
    public  float startscore = 0;
    public static float score;

    public static int  rounds;

    private void Start()
    {
        Money = startmoney;
        Lives = startLives;
        score = startscore;
        rounds = 0;
    }
   public float Scores()
    {
       

        float partialscore=0;

        partialscore = Lives * (Money+rounds);
 float finalscore;
        return finalscore=partialscore/100;
    }
  }

