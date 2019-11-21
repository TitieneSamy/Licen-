using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public float explosionradius = 0f;
    public GameObject impacteffect;

    public int damage = 15;


    public void Seek(Transform _target)
    {
        target = _target;
    }


	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

Vector3 dir = target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisframe)
        {
            Hittarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisframe,Space.World);
        transform.LookAt(target);
    }

    private void Hittarget()
    {
       GameObject effectbullet = (GameObject) Instantiate(impacteffect,transform.position,transform.rotation);
        Destroy(effectbullet,2f);
        if(explosionradius >=0f)
        {
            Explode();
        }
        else
        {

            Damage(target);
        }

        
       // Debug.Log("Am lovit ceva");
    }

    private void Explode()
    {
       Collider[] colliders= Physics.OverlapSphere(transform.position,explosionradius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Emeny")
                Damage(collider.transform);
        }
    }

    void Damage(Transform emeny)
    {
       Enemy e = emeny.GetComponent<Enemy>();
      
        if(e!=null)
        {
           e.Takedamage(damage);
           
        }

        
       
       
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionradius);
    }
}
