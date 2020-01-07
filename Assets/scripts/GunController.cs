using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunTransform;

    public bool isAutomatic;

    public GameObject projectile;

    public AudioSource gunRacking;
    public AudioSource gunfire;
    public AudioSource gunfireTail;
    public AudioSource casingFalling;

    public ParticleSystem muzzleFlash;

    public int fireRate;
    float shotsPerSecond;
    public float bulletVelocity;

    float timeSinceFire;

    // Start is called before the first frame update
    void Start()
    {
        shotsPerSecond = fireRate / 60;
        gunRacking.Play();
    }

    // Update is called once per frame
    void Update()
    {

        muzzleFlash.Stop();
        if (isAutomatic) {
            if (Input.GetMouseButton(0) && timeSinceFire >= 1 / shotsPerSecond)
            {
                projectileFire();
                gunfire.Play();
                gunfireTail.Play();

                muzzleFlash.Play();
                timeSinceFire = 0;
            }
            timeSinceFire += Time.deltaTime;
        }

        else if (!isAutomatic)
        {
            if (Input.GetMouseButtonDown(0) && timeSinceFire >= 1 / shotsPerSecond)
            {
                projectileFire();
                gunfire.Play();
                gunfireTail.Play();

                muzzleFlash.Play();
                timeSinceFire = 0;
            }
            timeSinceFire += Time.deltaTime;
        } 
    }

    void rayCastFire()
    {

    }
    void projectileFire()
    {
        GameObject bullet = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), gunTransform.rotation) as GameObject;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletVelocity);
    }
    
}
