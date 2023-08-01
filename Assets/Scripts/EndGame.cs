using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public string sceneName; // The name of the scene to load. Set this in the Inspector.

    //Trigger on collide.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"));
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneName);
        }
    }
}
