using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class bad_guy_follow : MonoBehaviour
{
    public GameObject good_g;

    //All Variables
    public float detectDistance = 10.0f; //within this distance, the good guy is detected
    public float closeEnough = 1.0f; //within this distance, object stop moving
    public float frequency = 0.2f; //frequency in percent that changes random position

    public float areaX = 50.0f; //x length of the ground
    public float areaZ = 50.0f; //z length of the ground
    public Vector3 starting_pos = Vector3.zero; //starting position of this stuff

    public bool detected = false; //decected the object or not


    public NavMeshAgent agent;


    void Start()
    {
        agent.SetDestination(new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f)));
        starting_pos = new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f));
        this.transform.position = starting_pos;
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, good_g.transform.position) <= detectDistance)
        { 
            follow();
            detected = true;
        }

        else
        {
            randomGo();
            detected = false;
        }


    }

    void follow()
    {
        agent.SetDestination(good_g.transform.position);
    }

    void randomGo()
    {
        if (Random.Range(0.0f, 100.0f) <= frequency)
            agent.SetDestination(new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f)));
    }
}
