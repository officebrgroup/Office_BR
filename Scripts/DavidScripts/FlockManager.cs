using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;

    [Range(1.0f, 10.0f)]
    public float neighborDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    public Vector3 goalPos;

    public GameObject fishPrefab;  // The object that will be used to generate
    public int numFish = 20;       // The number of fishes
    public GameObject[] allFish;   // The array of fishes
    public Vector3 swimLimits = new Vector3(5, 5, 5); // The limits of the swim place

    // Start is called before the first frame update
    void Start()
    {
        goalPos = this.transform.position;
        allFish = new GameObject[numFish];

        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = this.transform.position +
              new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                   Random.Range(-swimLimits.y, swimLimits.y),
                   Random.Range(-swimLimits.z, swimLimits.z));



            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Random.Range(0, 100) < 20)
            goalPos = new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
             Random.Range(-swimLimits.y, swimLimits.y),
             Random.Range(-swimLimits.z, swimLimits.z));
    }
}
