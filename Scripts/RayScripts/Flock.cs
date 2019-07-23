using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager;
    float speed;
    void ApplyRules()
    {
        GameObject[] gObjects;
        gObjects = myManager.allPlayer;

        Vector3 vcentre = Vector3.zero; //Vector that will hold the average center of the flock
        Vector3 vavoid = Vector3.zero; // vector that will hold the average direction to avoid
        int avoidSize = 0; // number of fishes in the group
        int neighborSize = 0;
        foreach(GameObject x in gObjects)
        {
            if(Vector3.Distance(x.transform.position,this.transform.position)<=myManager.neighborDistance)
            {
                vcentre += x.transform.position;
                neighborSize++;
            }
            if(Vector3.Distance(x.transform.position,this.transform.position) <= myManager.avoidDistance)
            {
                vavoid += (x.transform.position - this.transform.position);
                avoidSize++;
            }
        }
        vavoid *= -1;
        vavoid /= avoidSize;
        vcentre = vcentre / neighborSize + myManager.goalPos.transform.position - this.transform.position;
        Vector3 direction = vcentre + vavoid - this.transform.position;
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
        ApplyRules();
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
