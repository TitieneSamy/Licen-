using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackai : MonoBehaviour
{

    private Transform Target;
    public Enemyai targetEmeny;
    [Header("General")]
    public float range = 15f;
    [Header("Use Bullets(default)")]
    public GameObject bulletprefab;


    public float firerate = 1f;
    private float firecountdown = 0f;
  



    [Header("Unity Essentials")]
    public string emenytag = "Turret";
    public Transform parttorotate;
    public float turnspeed = 10f;
    public Transform firepoint;
   

    // Use this for initialization
    void Start()
    {
        targetEmeny = GetComponent<Enemyai>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }
    void UpdateTarget()
    {
        GameObject[] emenyies = GameObject.FindGameObjectsWithTag(emenytag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestemeny = null;
        foreach (GameObject emeny in emenyies)
        {
            float distancetoenemy = Vector3.Distance(transform.position, emeny.transform.position);
            if (distancetoenemy < shortestDistance)
            {
                shortestDistance = distancetoenemy;
                nearestemeny = emeny;
            }
        }

        if (nearestemeny != null && shortestDistance <= range)
        {
            Target = nearestemeny.transform;
            targetEmeny = nearestemeny.GetComponent<Enemyai>();
        }
        else
        {
            Target = null;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
           
            return;
        }

       

     

        else
        { Lockontarget();
            if (firecountdown <= 0)
            {
                Shoot();
                firecountdown = 1f / firerate;
            }
            firecountdown -= Time.deltaTime;

        }

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
        GameObject bulletgo = (GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletgo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(Target);
        }
    }









    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
