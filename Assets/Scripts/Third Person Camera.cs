using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform cam;
    public float speed = 6f;
    public bool IsWalking;

    public float SmoothTime = 0.1f;
    float turnSmoothVelocity = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxisRaw("Horizontal");
       float vertical = Input.GetAxisRaw("Vertical");
       Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

       if (direction.magnitude >= 0.1f)
       {

          float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
          float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, SmoothTime);
          transform.rotation = Quaternion.Euler(0f, angle, 270f);


      }
     
    }
}
