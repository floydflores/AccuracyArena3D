using UnityEngine;
using UnityEngine.UI;

public class VisibilityPosition : MonoBehaviour
{
    public CanvasGroup target;
    public float spawnPosition = -10f;
    public float destroyPosition = 100f; // The position at which the object should be destroyed

    private void Update()
    {
        if (target.transform.position.z <= spawnPosition)
        {
            target.alpha = 1; // Destroy the object
        }
        
        if (target.transform.position.z <= destroyPosition)
        {
            target.alpha = 0; // Destroy the object
        }
    }
}
