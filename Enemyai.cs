using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyai : MonoBehaviour {

    public float starthealth = 100f;

    [Header("Unity Stuff")]
    public Image Healthbar;

    [HideInInspector]
    public float health;

    private bool isDead = false;

    public GameObject destroyeffect;
    // Use this for initialization
    void Start () {
        health = starthealth;
    }

    // Update is called once per frame
    public void Takedamage(float amount)
    {
        health -= amount;

        Healthbar.fillAmount = health / starthealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }


    }

    public void Die()
    {
        isDead = true;
       

        FindObjectOfType<AudioManager>().Play("Destroyemeny");

        Destroy(gameObject);
        GameObject effect = (GameObject)Instantiate(destroyeffect, gameObject.transform.position, Quaternion.identity);


        // PlayerStats.Money +=50;
        Destroy(effect, 3f);
        return;
    }
}
