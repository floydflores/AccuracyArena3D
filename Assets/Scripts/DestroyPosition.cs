using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPosition : MonoBehaviour
{
    public GameObject target;
    public float destroyPosition = -10f; // The position at which the object should be destroyed

    private void Update()
    {
        if (target.transform.position.y <= destroyPosition)
        {
            Destroy(gameObject); // Destroy the object
        }
    }
}
