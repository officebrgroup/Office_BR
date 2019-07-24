using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody rb;
    public int damage = 10;




    void OnTriggerEnter(Collider hitInfo)
    {
        print(hitInfo);
        Destroy(gameObject);
        Health enemy = hitInfo.GetComponent<Health>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
