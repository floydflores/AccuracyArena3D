using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitGun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        projectileRigidbody.velocity = transform.forward * projectileSpeed;
    }
}