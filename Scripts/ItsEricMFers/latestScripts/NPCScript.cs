using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCScript : MonoBehaviour
{

    public GameObject enemyControl;
    public GameObject NPCControl;

    //All Variables
    public float detectDistance = 10.0f; //within this distance, the good guy is detected
    public float frequency = 0.2f; //frequency in percent that changes random position

    public float areaX = 50.0f; //x length of the ground
    public float areaZ = 50.0f; //z length of the ground
    public Vector3 starting_pos = Vector3.zero; //starting position of this stuff

    public NavMeshAgent agent;

    bool isFollowing;
    int closest_tag;
    int always_tag;

    float closest;


    void Start()
    {
        enemyControl = GameObject.FindGameObjectWithTag("Enemy_Manager");
        NPCControl = GameObject.FindGameObjectWithTag("npccontrol");

        isFollowing = false; // if it is already following
        closest = detectDistance * 100.0f + 1.0f;
        closest_tag = 0;
        always_tag = 0;
        
    }

    void Update()
    {
        GameObject[] enemys = enemyControl.GetComponent<EnemyManager>().allEnemy;

        for (int m = 0; m < (enemyControl.GetComponent<EnemyManager>().numEnemy+1) ; m++)
        {
            if (Vector3.Distance(this.transform.position, enemys[m].transform.position) <= closest)
            {
                closest = Vector3.Distance(this.transform.position, enemys[m].transform.position);
                closest_tag = m;
            }
        }

        if (isFollowing == false)
        {
            if (closest <= detectDistance)
            {
                agent.SetDestination(enemys[closest_tag].transform.position);
                isFollowing = true;
                always_tag = closest_tag;
            }
            else
            {
                randomGo();
            }
        }
        else
        {
            agent.SetDestination(enemys[always_tag].transform.position);
        }


    }

    void randomGo()
    {
        if (Random.Range(0.0f, 100.0f) <= frequency)
            agent.SetDestination(new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f)));
    }
}
