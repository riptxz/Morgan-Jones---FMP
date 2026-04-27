using UnityEngine;

public class Fan : MonoBehaviour
{
    float windPower = 25f;
    

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(-transform.right * windPower);   
            print("Something has collided"); 
        }
        
    }

    private void Start()
    {
        
    }

}
