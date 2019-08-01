using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject enemyControl;

    //public GameObject NPCControl;

    public GameObject NPCPrefab; //the prefab of the enemy
    public float genDetectDistance = 10.0f; 
    public int numNPC = 10; //number of enemies
    public GameObject[] allNPC; //array of enemies
    public Vector3 spaceLimit = new Vector3(150, 150, 150);
    public List<int> hostList; //the list indicating all the hosts
   

    // Start is called before the first frame update
    void Start()
    {
        //NPCControl = GameObject.Find("npccontrol");
        enemyControl = GameObject.Find("Enemy_Manager");
        //enemyControl.GetComponent<EnemyManager>().allEnemy
        allNPC = new GameObject[numNPC];
        int i = 0;
        while (i < numNPC)
        {
            Vector3 pos = this.transform.position +
                new Vector3(Random.Range(-spaceLimit.x, spaceLimit.x),
                0,
                Random.Range(-spaceLimit.z, spaceLimit.z));
            if (!Physics.CheckSphere(pos, 0.5f))
            {
                allNPC[i] = (GameObject)Instantiate(NPCPrefab, pos, Quaternion.identity);
                i++;
            }

        }
    }

   

    // Update is called once per frame
    void Update()
    { 

    }
}
