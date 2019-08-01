using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyScript : MonoBehaviour
{
    public float frequency = 0.2f; //frequency in percent that changes random position

    public NavMeshAgent agent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomGo();
    }

    void randomGo()
    {
        if (Random.Range(0.0f, 100.0f) <= frequency)
            agent.SetDestination(new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f)));
    }
}
