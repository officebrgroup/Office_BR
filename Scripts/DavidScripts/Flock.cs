using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager;
    float speed;

    bool turning = false;


    private bool isClose = false;

    void ApplyRules()
    {
        GameObject[] gObjects;
        gObjects = myManager.allFish;

        Vector3 vcentre = Vector3.zero; //Vector that will hold the average center of the flock
        Vector3 vavoid = Vector3.zero; // vector that will hold the average direction to avoid
        float gSpeed = 0.2f; // Average speed to have at the end
        float nDistance = 1.0f; // distance to neighbot
        int groupSize = 20; // number of fishes in the group
        Vector3 direction = Vector3.zero;
        int totNum = 1;

        //Reynolds algorithm implementation here!
        foreach (GameObject cur in gObjects)
        {
            if (Vector3.Distance(cur.transform.position, this.transform.position) < nDistance)
            {
                vavoid += this.transform.position - cur.transform.position;
            }

            if (Vector3.Distance(cur.transform.position, this.transform.position) <= myManager.neighborDistance)
            {
                totNum++;
                vcentre += cur.transform.position;
            }
        }

        vcentre = vcentre / totNum + (myManager.goalPos - this.transform.position);

        direction = vcentre + vavoid - this.transform.position;

        if (direction != Vector3.zero)
        {
            this.transform.rotation =
             Quaternion.Slerp(this.transform.rotation,
                 Quaternion.LookRotation(direction),
                 myManager.rotationSpeed * Time.deltaTime);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }



    // Update is called once per frame
    void Update()
    {
        Bounds b = new Bounds(myManager.transform.position, myManager.swimLimits * 2);
        // check if the position is within the boundary
        turning = !b.Contains(transform.position);

        if (turning)
        {
            Vector3 direction = myManager.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(
                 this.transform.rotation,
                 Quaternion.LookRotation(direction),
                 myManager.rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (Random.Range(0, 100) < 10)
                speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
            if (Random.Range(0, 100) < 20)
                ApplyRules();
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
        
    }
}
