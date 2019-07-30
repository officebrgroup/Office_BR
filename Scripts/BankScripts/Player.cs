using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 offset = new Vector3 (0, 10, -10);
    public GameObject gameCamera;
    private static string gunName;
    
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
    }
    
    public void loadGun()
    {
        GameObject Gun1 = Instantiate(Resources.Load(gunName, typeof(GameObject))) as GameObject;
        Gun1.transform.parent = this.transform;
        Gun1.transform.localPosition = new Vector3(0.5f, 0f, 0.5f);
        if (gunName == "AK47")
            Gun1.transform.rotation = Quaternion.Euler(0, 179, 0);
        else
        {
            Gun1.transform.rotation = Quaternion.Euler(0, -1, 0);
        }
    
    }

    

    void cameraFollow()
    {
        gameCamera.transform.position = this.transform.position + offset;
    }
    void Start()
    {
        gunName = MainMenu.GunName;
        Debug.Log(gunName);
        loadGun();
        

    }

    void Update()
    {
        mouse();
        keyboard();
        cameraFollow();
    }
}