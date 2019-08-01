using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player_object;

    public GameObject enemyPrefab;
    public Vector3 spaceLimit = new Vector3(150, 150, 150);
    public GameObject[] allEnemy;
    public int numEnemy = 10;

    // Start is called before the first frame update
    void Start()
    {
        allEnemy = new GameObject[numEnemy+1];
        int i = 0;
        while (i < numEnemy) { 
            Vector3 pos = this.transform.position +
                          new Vector3(Random.Range(-spaceLimit.x, spaceLimit.x),
                          0,
                          Random.Range(-spaceLimit.z, spaceLimit.z));
            if (!Physics.CheckSphere(pos, 0.5f))
            {
                allEnemy[i] = (GameObject)Instantiate(enemyPrefab, pos, Quaternion.identity);
                i++;
            }

        }


        allEnemy[numEnemy] = (GameObject)Instantiate(player_object);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
