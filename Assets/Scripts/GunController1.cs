using System.Collections;
using UnityEngine;
using TMPro;

public class GunController1 : MonoBehaviour
{
    [Header("Shooting")]
    public Transform muzzle;            // The point where bullets will be fired from
    public GameObject bulletPrefab;     // Prefab of the bullet GameObject
    public float fireRate = 0.1f;       // Time between shots
    public int maxAmmo = 10;            // Maximum ammo capacity
    public float bulletForce = 10f;     // Force to apply to the bullet
    public int damage = 22;

    [Header("Reloading")]
    private int currentAmmo; // Current ammo count
    private bool canShoot = true; // Flag to control shooting rate
    
    private bool isReloading; // Determines if player is reloading
    public float reloadTime = 1.5f; // Amount of time to reload

    public bool canChamber = false; // Determines if the weapon can chamber a round

    [Header("Effects")]
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletCasing;
    public AudioSource audioSource;
    public AudioClip shootingSoundEffect;
    public TextMeshProUGUI countText;
    public GameObject ReloadHeader;

    // Start is called before update
    private void Start()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        countText.text = currentAmmo.ToString();
        ReloadHeader.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isReloading)
            return;
        
        if (Input.GetButtonDown("Fire1") && canShoot && currentAmmo > 0)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonDown("Fire3") && currentAmmo < maxAmmo)
        {
            Reload();
        }
    }

    // Shoot the weapon
    private IEnumerator Shoot()
    {
        canShoot = false;
        currentAmmo--;
        countText.text = currentAmmo.ToString();

        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        if (bulletCasing != null)
        {
            bulletCasing.Play();
        }

        if (shootingSoundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootingSoundEffect);
        }

        // Instantiate the bullet prefab at the muzzle position and rotation
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        
        // Apply force to the bullet in the forward direction
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = muzzle.forward * bulletForce;

        // Raycast to detect hits
       RaycastHit hit;
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name);
            // You can apply damage to the hit object or trigger other effects here

            // Check if the object has a script/component to take damage
            Health healthController = hit.transform.GetComponent<Health>();
            if (healthController != null)
            {
            // Apply damage to the hit object
            healthController.TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    // Reload the weapon
    void Reload()
    {
        if (isReloading)
            return;

        isReloading = true;
        Debug.Log("Reloading...");
        ReloadHeader.SetActive(true);

        // Add any reloading visual/audio effects here

        // Simulate the reload time using a coroutine
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);

        // Reset the current ammo to max ammo
        currentAmmo = maxAmmo;
        ReloadHeader.SetActive(false);

        // Chamber an extra round if the ammo count > 0
        if (canChamber && currentAmmo > 0)
        {
            currentAmmo += 1;
        }

        // Reset the reloading flag
        isReloading = false;
        countText.text = currentAmmo.ToString();

        Debug.Log("Reload complete. Current ammo: " + currentAmmo);
    }
}
