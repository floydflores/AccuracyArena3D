using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string sceneName; // The name of the scene to load. Set this in the Inspector.
    public GameObject loader; // The name of the "loader" that activates the sequence.

    void Start()
    {
        loader = GameObject.FindWithTag("LoadScene").GetComponent<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadScene"))
        {
            LoadTheScene();
            Destroy(gameObject);
        }
    }

    public void LoadTheScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
