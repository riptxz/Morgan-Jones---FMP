using UnityEngine;

public class Fan : MonoBehaviour
{
    public float windPower = 10f;
   
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.left * windPower);
            print("Something has Collided");
        }
        
    }

}
