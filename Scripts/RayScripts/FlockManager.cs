using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject playerPrefab;  // The object that will be used to generate
    public int numPlayer = 20;       // The number of fishes
    public GameObject[] allPlayer;   // The array of fishes
    public Vector3 spaceLimits = new Vector3(5, 5, 5); // The limits of the swim place
    [Header("Player Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed = 0.3f;
    [Range(0.0f, 5.0f)]
    public float maxSpeed = 1.0f;
    [Range(1.0f, 10.0f)]
    public float neighborDistance = 4.0f;
    public float avoidDistance = 1.0f;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed = 1.2f;
    public GameObject goalPos;
    // Start is called before the first frame update
    void Start()
    {
        allPlayer = new GameObject[numPlayer];
        for (int i = 0; i < numPlayer; i++)
        {
            Vector3 pos = this.transform.position +
              new Vector3(Random.Range(-spaceLimits.x, spaceLimits.x),
                   Random.Range(-spaceLimits.y, spaceLimits.y),
                   Random.Range(-spaceLimits.z, spaceLimits.z));
            allPlayer[i] = (GameObject)Instantiate(playerPrefab, pos, Quaternion.identity);
            allPlayer[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
