using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    bool waitActive = false;
    public GameObject BulletType;
    public GameObject GunTip;
    public float ROF;
    private float nextTimeToFire = 0f;
    private float flashTime = 0.01f;
    public GameObject flash;

    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime;
    private bool isReloading = false;

    public GameObject Clip;
    public int chamberTime = 1;
    private bool canShoot = false;


    IEnumerator FlashWait()
    {
        yield return new WaitForSeconds(flashTime);
        flash.gameObject.SetActive(false);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading!!!");
        Instantiate(Clip, transform.position, Quaternion.Euler(new Vector3(180, 0, -180)));
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    IEnumerator Chamber()
    {
        Debug.Log("Chamer");
        yield return new WaitForSeconds(chamberTime);
        canShoot = true;
    }

    void shoot()
    {
        if (isReloading || !canShoot)
            return;
        if  (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            currentAmmo--;
            nextTimeToFire = Time.time + 60f/ROF;
            GameObject bullet = Instantiate(BulletType, GunTip.transform.position, GunTip.transform.rotation);
            flash.gameObject.SetActive(true);
            StartCoroutine(FlashWait());
        }
    }

    void pressR()
    {
        if(Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo != maxAmmo)
            StartCoroutine(Reload());
            return;
    }

    void Start()
    {
        flash.gameObject.SetActive(false);
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        pressR();
    }
    
    void OnEnable()
    {
        canShoot = false;
        isReloading = false;
        StartCoroutine(Chamber());
        
    }

}
