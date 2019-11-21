using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wavespanner : MonoBehaviour {

    public static int Enemyiesalive = 0;

    public Wave[] waves;
  
    public Transform emenyprefab;
    public Transform spawnpoint;
    public float timebetwenwaves = 7f;
    private float countdown = 3f;
    public Text Wavecountdowntext;
    public Gamemanager gamemanager;

    private int Wavenumber = 0;
    private void Update()
    {
        if(Enemyiesalive>0)
        {
            
            return; 
        }
        if (Wavenumber == waves.Length)
        {
            gamemanager.Levelwon();

            this.enabled = false;


        }
        if (countdown<=0f )
        {
            StartCoroutine(SpawnWave());
            countdown = timebetwenwaves;
            return;

        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        Wavecountdowntext.text =  "Urmatorul atac:" +  string.Format("{0:00.00}",countdown);

    }
    IEnumerator  SpawnWave()
    {        
       
      PlayerStats.rounds++;  

Wave wave = waves[Wavenumber];

         Enemyiesalive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            Spawnemeny(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

       Wavenumber++;
        //  Debug.Log("Vin Inamicii!");

        

       

      
    } 

    private void Spawnemeny(GameObject enemy)
    {

        Instantiate(enemy,spawnpoint.position,spawnpoint.rotation);
        return;
    
    }
}
