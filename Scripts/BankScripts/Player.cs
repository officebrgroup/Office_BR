using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 offset;
    public GameObject gameCamera;
    public GameObject BulletType;
    public GameObject GunTip;
    bool waitActive = false;
    public float timePerBullet = 0.2f;


    IEnumerator fireRate(){
        waitActive = true;
        yield return new WaitForSeconds (timePerBullet);
        waitActive = false;
    }

    void keyboard()
    {
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(new Vector3 (-speed * Time.deltaTime, 0, 0), Space.World);
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(new Vector3 (speed * Time.deltaTime, 0, 0), Space.World);
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(new Vector3 (0, 0, speed * Time.deltaTime), Space.World);
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(new Vector3 (0, 0, -speed * Time.deltaTime), Space.World);
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 10;
        else
        {
            speed = 5;
        }
    }

    void mouse()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if(Physics.Raycast(ray,out hit,100))
        {
            transform.LookAt(new Vector3 (hit.point.x,transform.position.y,hit.point.z));
        }
        // if(Input.GetMouseButton(0))
        // {
        //     if (!waitActive)
        //     {
        //         Instantiate(BulletType, GunTip.transform.position, GunTip.transform.rotation);
        //         Debug.Log(hit.transform.name);
        //         StartCoroutine(fireRate());
        //     }
        // }
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
        mouse();
        keyboard();
        cameraFollow();
    }
}