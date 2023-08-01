using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform weaponSocket; // Reference to the WeaponSocket GameObject.

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // You can add a check here to see if the player can actually pick up the weapon (e.g., if the player has space in the inventory).

            PickUpWeapon(other.gameObject);
        }
    }

    void PickUpWeapon(GameObject player)
    {
        // Instantiate the weaponPrefab and attach it to the WeaponSocket.
        GameObject weaponInstance = Instantiate(weaponPrefab);
        weaponInstance.transform.SetParent(weaponSocket); // Attach the weapon to the WeaponSocket.
        weaponInstance.transform.localPosition = Vector3.zero; // Adjust the position relative to the WeaponSocket.
        weaponInstance.transform.localRotation = Quaternion.identity; // Adjust the rotation relative to the WeaponSocket.

        // Disable the pickup GameObject to make it disappear from the scene.
        gameObject.SetActive(false);
    }
}
