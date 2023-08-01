using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController1 : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;
    public int maxAmmo = 30; // Change this value to modify the weapon's capacity.
    public float reloadTime = 1.5f;

    private int currentAmmo;
    private bool isReloading;
    private bool hasRoundChambered; // New variable to track if there is a chambered round.
    private float nextFireTime;

    public ParticleSystem muzzleFlash;

    void Start()
    {
        currentAmmo = maxAmmo;
        hasRoundChambered = false; // Start without a chambered round.
    }

    void Update()
    {
        if (isReloading)
            return;

        // Check if there is any ammo left or a chambered round to fire.
        if (currentAmmo <= 0 && !hasRoundChambered)
        {
            // Initiate reloading when there's no ammo and no chambered round.
            Reload();
            return;
        }

        // Check if the player can fire (has ammo or a chambered round) and enough time has passed since the last shot.
        if ((Input.GetButtonDown("Fire1") || (Input.GetButton("Fire1") && hasRoundChambered)) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
            Debug.Log("Firing!");
        }
    }

    void Fire()
    {
        if (hasRoundChambered)
        {
            // Firing consumes the chambered round.
            hasRoundChambered = false;

            // If you want to display the chambered round visually, you can add relevant UI/visuals here.

            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = transform.forward * projectileSpeed;
        }

        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
    }

    void Reload()
    {
        if (isReloading)
            return;

        isReloading = true;
        Debug.Log("Reloading...");

        // Add any reloading visual/audio effects here

        // Simulate the reload time using a coroutine
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);

        // Calculate how many rounds need to be reloaded.
        int roundsToReload = maxAmmo - currentAmmo;

        // If there are more rounds than needed for the chamber, set the chambered round and reduce the ammo count accordingly.
        if (roundsToReload > 1)
        {
            currentAmmo += roundsToReload - 1;
            hasRoundChambered = true;
        }
        else if (roundsToReload == 1)
        {
            hasRoundChambered = true;
        }

        isReloading = false;
        Debug.Log("Reloaded!");
    }
}
