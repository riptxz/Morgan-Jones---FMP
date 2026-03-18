using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    InputAction moveAction;

    States state;
    
    Rigidbody rb;
    public bool isgrounded;

    public enum States // used by all logic
    {
        None,
        Idle,
        Move,
        Jump,
        ChargedJump,
    }
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>(); // defines the rigidbody
        state = States.Idle;    // Player always starts in idle

        moveAction = InputSystem.actions.FindAction("Move");  // Finding the action in the Input System
    }

    
    public void FixedUpdate()
    {
        DoLogic();          
    }

    public void DoLogic()
    {
        if(state == States.Idle)
        {
            Idle();
        }

        if(state == States.Move)
        {
            PlayerMove();
        }
    }

   public void Idle()
    {
        if (moveAction.IsPressed())
        {
            state = States.Move;
        }
    }

   public void PlayerMove()
    {
        Vector3 vel;
        float magnitude = rb.linearVelocity.magnitude;

        if (isgrounded = true && moveAction.IsPressed())
        {
            vel = transform.forward * 10f;
            rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);

        }
        else if(moveAction.IsPressed() == false)
        {
            vel = transform.forward * 0.1f;
            rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
            state = States.Idle;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isgrounded = true;
            print("landed!");
        }

    }
}
