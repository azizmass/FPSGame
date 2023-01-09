using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Camera fpsCam;
    [SerializeField] float range = 100f;
    public ParticleSystem muzzleFlash;

    public float fireRate = 20;

    float nextTimeToFire = 0f;
    public float damage = 20f;
    void Awake()
    {
        fpsCam = Camera.main;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            HealthManager hm = hit.transform.GetComponent<HealthManager>();
            // If we hit an object with a HealthManager
            if (hm)
            {
                // Deal damage
                hm.TakeDamage(damage);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    }

