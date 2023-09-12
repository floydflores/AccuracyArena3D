using UnityEngine;
using UnityEngine.UI;

public class VisibilityPosition : MonoBehaviour
{
    public CanvasGroup target;
    public float destroyPosition = 100f;

    private void Update()
    {
        // Calculate the distance between the player and the notification along the Z-axis
        float distance = Mathf.Abs(target.transform.position.z - transform.position.z);

        if (distance >= destroyPosition)
        {
            target.alpha = 0; // Make the object invisible
            Destroy(gameObject); // Destroy the GameObject this script is attached to
        }
        else
        {
            // Object is within the desired distance, so set visibility to 1
            target.alpha = 1; // Make the object visible
        }
    }
}
