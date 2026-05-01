
using UnityEngine;

public class DestroySelf : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerScript.Mold = PlayerScript.Mold - 30f;  // Gets the Players mold from PlayerScript and takes away 30 from it when picking up the powerup
            
            if (PlayerScript.Mold < 0)         // Prevents Mold from being negative 
            {
                PlayerScript.Mold = 0;
            }
            
            Destroy(gameObject);
        }
    }
}
