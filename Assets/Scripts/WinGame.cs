using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Win Screen");
        }

    }
}
