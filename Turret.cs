using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    private Transform Target;
    private Enemy targetEmeny;
    [Header("General")]
    public float range = 15f;
    [Header("Use Bullets(default)")]
    public GameObject bulletprefab;


    public float firerate=1f;
    private float firecountdown = 0f;
    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer linerender;
    public int damageovertime=30;
     public ParticleSystem laserimpacteffect;
    public float slowamount = .5f;

    [Header("Unity Essentials")]
    public string emenytag = "emeny";
    public Transform parttorotate;
    public float turnspeed = 10f;
    public Transform firepoint;
public int health = 30;

	// Use this for initialization
	void Start () {
        targetEmeny = GetComponent<Enemy>();
        InvokeRepeating("UpdateTarget",0f,0.5f);

	}
	void UpdateTarget()
    {
        GameObject[] emenyies = GameObject.FindGameObjectsWithTag(emenytag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestemeny = null;
        foreach (GameObject emeny in emenyies)
        {
            float distancetoenemy = Vector3.Distance(transform.position,emeny.transform.position);
            if(distancetoenemy< shortestDistance)
            {
                shortestDistance = distancetoenemy;
                nearestemeny = emeny;
            }
        }
        
        if(nearestemeny != null && shortestDistance<=range)
        {
            Target = nearestemeny.transform;
            targetEmeny = nearestemeny.GetComponent<Enemy>();
        }
        else
        {
            Target = null;
        }

    }
	// Update is called once per frame
	void Update () {
        if (Target == null)
        {
            if(useLaser)
            {
                if (linerender.enabled)
                {
linerender.enabled = false;
                   laserimpacteffect.Stop();
                }
                    
            }
 return;
        }
           
        Lockontarget();

        if (useLaser)
        {
          
        Laser();
        }
           
        else
        {
            if (firecountdown <= 0)
            {
                Shoot();
                firecountdown = 1f / firerate;
            }
            firecountdown -= Time.deltaTime;

        }
        
    }

    private void Laser()
    {
        FindObjectOfType<Enemy>();
        targetEmeny.GetComponent<Enemy>().Takedamage(damageovertime * Time.deltaTime);
        targetEmeny.Slow(slowamount);
        if(targetEmeny==null)
        {
 return;
        }
       

        if (!linerender.enabled)

            
        {
            linerender.enabled = true;
         laserimpacteffect.Play();
            FindObjectOfType<AudioManager>().Play("LaserFire");

        }
        linerender.SetPosition(0, firepoint.position);
        linerender.SetPosition(1, Target.position);

      
        Vector3 dir = firepoint.position - Target.position;
 laserimpacteffect.transform.position = Target.position = Target.position;
        laserimpacteffect.transform.rotation = Quaternion.LookRotation(dir);
       
    }

    private void Lockontarget()
    {
        Vector3 dir = Target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 roatation = Quaternion.Lerp(parttorotate.rotation, lookrotation, Time.deltaTime * turnspeed).eulerAngles;
        parttorotate.rotation = lookrotation;
    }

    public void Shoot()
    {
        // Debug.Log("Trage");
     GameObject bulletgo=(GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletgo.GetComponent<Bullet>();

        if(bullet!=null)
        {
            bullet.Seek(Target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
