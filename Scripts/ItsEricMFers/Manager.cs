using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject enemyPrefab; //the prefab of the enemy
    public int numEnemy = 10; //number of enemies
    public GameObject[] allEnemy; //array of enemies
    public Vector3 spaceLimit = new Vector3(50, 50, 50);

    // Start is called before the first frame update
    void Start()
    {
        allEnemy = new GameObject[numEnemy];
        for (int i=0; i<numEnemy; i++)
        {
            Vector3 pos = this.transform.position +
                new Vector3(Random.Range(-spaceLimit.x, spaceLimit.x),
                0,
                Random.Range(-spaceLimit.z, spaceLimit.z));
            allEnemy[i] = (GameObject)Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
