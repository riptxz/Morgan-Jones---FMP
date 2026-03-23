
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    InputAction moveAction;
    InputAction jumpAction;

    States state;
    
    Rigidbody rb;
    public bool isgrounded;
    bool isMolding;

    public float JumpPower;
    public float force = 100f;
    float Mold = 0f;
    

    public enum States // used by all logic
    {
        None,
        Idle,
        Move,
        ChargedJump,
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>(); // defines the rigidbody
        state = States.Idle;    // Player always starts in idle

        isMolding = false;

        jumpAction = InputSystem.actions.FindAction("Jump");  // Finding the action in the Input System
        moveAction = InputSystem.actions.FindAction("Move");  // Finding the action in the Input System
    }

    
    public void FixedUpdate()
    {
        DoLogic();
        
        if (isMolding)
        {
            Molding();
        }
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

        if (state == States.ChargedJump)
        {
            ChargedJump();
        }
    }

   public void Idle()
    {
        if (moveAction.IsPressed())
        {
            state = States.Move;
        }

        if (jumpAction.IsPressed())
        {
            state = States.ChargedJump;
        }
    }

   public void PlayerMove()
    {
        Vector3 vel;
        float magnitude = rb.linearVelocity.magnitude;

        if (moveAction.IsInProgress())
        {
            vel = transform.forward * 10f;
            rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
        }

        else if(moveAction.IsInProgress() == false)
        {
            vel = transform.forward * 0.1f;
            rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
            state = States.Idle;
        }
    }

    public void ChargedJump()
    {
        if(jumpAction.IsInProgress() && isgrounded == true)  // Checkng if space is held
        {
            JumpPower += Time.deltaTime * 4f;
        }
        
        if (jumpAction.IsInProgress() == false && isgrounded == true)   // Checking if space is released
        {
            isgrounded = false;
            isMolding = false;
            rb.AddForce(Vector3.up * JumpPower * force);
            JumpPower = 1f;
            state = States.Idle;
        }
    }

    public void Molding()
    {
        if(isMolding == true)
        {
            Mold += Time.deltaTime;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "DirtySurface")
        {
            isgrounded = true;
            print("landed!");
        }

        if(col.gameObject.tag == "DirtySurface")
        {
            isMolding = true;
            print("landed on dirty surface!");
        }
    }

    private void OnGUI()
    {

        //debug text
        string text = "\nCurrent state =" + state;
        text += "\nCurrent Jump Power =" + JumpPower;
        text += "\nMold = " + Mold;


        // define debug text area
        GUILayout.BeginArea(new Rect(10f, 450f, 1600f, 1600f));
        GUILayout.Label($"<size=16>{text}</size>");
        GUILayout.EndArea();
    }
}

