using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeys : MonoBehaviour
{
    public float speed = 0.01f;
    private Vector3 offset;
    public GameObject gameCamera;
    
    // private Vector3 worldpos;
    // private float mouseX;
    // private float mouseY;
    // private float cameraDif;
    // private Vector3 pos;
    void wasd()
    {
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(new Vector3 (-speed * Time.deltaTime, 0, 0), Space.World);
        if (Input.GetKey(KeyCode.D))
            // this.transform.Translate(speed * Time.deltaTime, 0, 0);
            this.transform.Translate(new Vector3 (speed * Time.deltaTime, 0, 0), Space.World);
        if (Input.GetKey(KeyCode.W))
            // this.transform.Translate(0, 0, speed * Time.deltaTime);
            this.transform.Translate(new Vector3 (0, 0, speed * Time.deltaTime), Space.World);
        if (Input.GetKey(KeyCode.S))
            // this.transform.Translate(0, 0, -speed * Time.deltaTime);
            this.transform.Translate(new Vector3 (0, 0, -speed * Time.deltaTime), Space.World);
    }

    void aim()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if(Physics.Raycast(ray,out hit,100))
        {
            transform.LookAt(new Vector3(hit.point.x,transform.position.y,hit.point.z));
        }
        
        

        // cameraDif = GetComponent<Camera>().transform.position.y - this.transform.position.y;
        // mouseX = Input.mousePosition.x;
        // mouseY = Input.mousePosition.y;
        // pos = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));
        // Vector3 direction = new Vector3 (pos.x, this.transform.position.y, pos.z);
        // this.transform.LookAt(direction);
    }

    void cameraFollow()
    {
        
        gameCamera.transform.position = this.transform.position + offset;
        //print(offset);
    }
    void Start()
    {
        offset = gameCamera.transform.position - this.transform.position;
    }

    void Update()
    {
        aim();
        wasd();
        cameraFollow();
    }
}