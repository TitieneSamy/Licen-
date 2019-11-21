using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Movedestination : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    public Vector3 position;
    
    void Start()
    {        
        agent = GetComponent<NavMeshAgent>();

        agent.destination = goal.position;
            
    }

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {           
            PlayerStats.Lives--;
            Destroy(gameObject);
            Wavespanner.Enemyiesalive--;
            FindObjectOfType<AudioManager>().Play("Destroyemeny");
            FindObjectOfType<AudioManager>().Play("Attackbase");
            return;
        }
    }
}

