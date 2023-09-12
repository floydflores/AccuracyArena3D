using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPosition : MonoBehaviour
{
    public GameObject target;
    public float destroyPosition = -10f; // The position at which the object should retry.

    private void Update()
    {
        if (target.transform.position.y <= destroyPosition)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Retrying"); // Try again.
        }
    }
}
