using UnityEngine;

public class Fan : MonoBehaviour
{
    public float windPower = 1.5f;
    public float force = 10f;
    

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(-transform.right * windPower * force);
            print("Something has collided");
        }
        
    }

    private void Start()
    {
        
    }

}
