using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; 

public class Enemy : MonoBehaviour
{
    public float starthealth = 100f;
   

    [HideInInspector]
    public float health;
    private Vector3 offset;


    [Header("Unity Stuff")]
    public Image Healthbar;

    public int worth;

    public float startspeed = 10f;

    [HideInInspector]
    public float speed;

    private bool isDead = false;

    public GameObject destroyeffect;

   
  

    private void Start()
    {
        


        health = starthealth;
        speed = startspeed;
    }


    public void Takedamage(float amount)
    {
        health -= amount;

        Healthbar.fillAmount =health/starthealth;
       
        if(health<=0 && !isDead)
        {
            Die();
        }
      

    }

  public  void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;

        FindObjectOfType<AudioManager>().Play("Destroyemeny");

        Destroy(gameObject);
           GameObject effect = (GameObject)Instantiate(destroyeffect, gameObject.transform.position, Quaternion.identity);
      

        Wavespanner.Enemyiesalive--;
       // PlayerStats.Money +=50;
               Destroy(effect, 3f);
        return;
    }

    internal void Slow(float slowamount)
    {
        speed = startspeed * (1 - slowamount);
    }
}
