using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    bool waitActive = false;
    public GameObject BulletType;
    public GameObject GunTip;
    public bool canSwitch = true;
    public float ROF;
    private float nextTimeToFire = 0f;
    private float flashTime = 0.01f;
    public GameObject flash;


    IEnumerator FlashWait()
    {
        yield return new WaitForSeconds(flashTime);
        flash.gameObject.SetActive(false);
    }
    void shoot()
    {
        if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 60f/ROF;
            Instantiate(BulletType, GunTip.transform.position, GunTip.transform.rotation);
            flash.gameObject.SetActive(true);
            StartCoroutine(FlashWait());
        }
    }

    void Start()
    {
        flash.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }
}
