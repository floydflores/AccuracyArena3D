using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string sceneName; // The name of the scene to load. Set this in the Inspector.
    public Transform targetDestination; // The target destination game object or position. Set this in the Inspector.

    private bool hasReachedDestination = false;

    private void Update()
    {
        if (!hasReachedDestination)
        {
            CheckDestinationReached();
        }
    }

    private void CheckDestinationReached()
    {
        // Calculate the distance between the current position and the target destination
        float distanceToTarget = Vector3.Distance(transform.position, targetDestination.position);

        // Check if the distance is below a threshold value (adjust the threshold as needed)
        if (distanceToTarget > 205)
        {
            hasReachedDestination = true;
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}