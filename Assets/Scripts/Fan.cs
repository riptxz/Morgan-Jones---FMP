using UnityEngine;

public class Fan : MonoBehaviour
{
    public float windPower = 10f;
    

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().linearVelocity = -transform.right * windPower;
            print("Something has collided");
        }
        
    }

    private void Start()
    {
        
    }

}
