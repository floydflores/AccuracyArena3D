using UnityEngine;
using UnityEngine.UI;

public class CheckpointN : MonoBehaviour
{
    public GameObject CheckPoint;
    public GameObject LoadThing;
    public GameObject UnloadThing;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadThing.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<GameObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(CheckPoint);
            LoadThing.SetActive(true);
            UnloadThing.SetActive(false);
        }
    }
}
