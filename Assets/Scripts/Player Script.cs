
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    InputAction moveAction;
    InputAction jumpAction;

    States state;
    
    Rigidbody rb;
    public bool isGrounded;
    bool isMolding;
    bool isDead;
    bool isLaunching;

    [Range(0f, 5f)] float jumpPower = 0f;
    float launchPower = 21.5f;
    public float force = 100f;
    float Mold = 0f;
    float speed = 20f;
    

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
        
        if (isMolding)     // If colliding with dirty ground start molding
        {
            Molding();
        }

        if (isLaunching)
        {
            Launch();
        }

        DoLogic();

    }

    public void Update()
    {
        if (isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Mold > 100f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        // Vector3 vel;
        // float magnitude = rb.linearVelocity.magnitude;

        if (moveAction.IsInProgress())
        {
            rb.AddForce(Vector3.forward * speed * force);

           // vel = transform.forward * 10f;
           // rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
        }

        else
        {
            rb.AddForce(Vector3.back * speed);
           // vel = transform.forward * 0.1f;
           // rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
            state = States.Idle;
        }
    }

    public void ChargedJump()
    {

        if (jumpAction.IsInProgress() && isGrounded == true)  // Checkng if space is held
        {
            jumpPower += Time.deltaTime * 10f;

            if(jumpPower > 7f)
            {
               jumpPower = 7f;
            }
        }
        
        if (jumpAction.IsInProgress() == false && isGrounded == true)   // Checking if space is released
        {
            isGrounded = false;
            isMolding = false;
            rb.AddForce(Vector3.up * jumpPower * force);
            jumpPower = 1f;
            state = States.Idle;
        }
    }

    public void Molding()
    {
        if (isMolding == true && isGrounded)
        {
            Mold += Time.deltaTime * 5f;
        }
        else
        {
            isMolding = false;
        }
    }


    public void Launch()
    {
        if (isLaunching && isGrounded)
        {
            rb.AddForce(Vector3.up * launchPower * force);
            isGrounded = false;
            isMolding = false;
            isLaunching = false;
        }
        
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "DirtySurface" || col.gameObject.tag == "LaunchPad")
        {
            isGrounded = true;
            print("landed!");
        }

        if(col.gameObject.tag == "DirtySurface")
        {
            isMolding = true;
            print("landed on dirty surface!");
        }

        if(col.gameObject.tag == "Obstacle")
        {
            isDead = true;
            print("Died to Obstacle");
        }

        if(col.gameObject.tag == "LaunchPad")
        {
            isLaunching = true;
            print("Being launched");
        }

    }

    private void OnGUI()
    {

        //debug text
         string text = "\nCurrent state =" + state;
         text += "\nCurrent Jump Power =" + jumpPower;
         text += "\nMold = " + Mold;


        // define debug text area
        GUILayout.BeginArea(new Rect(10f, 450f, 1600f, 1600f));
        GUILayout.Label($"<size=16>{text}</size>");
        GUILayout.EndArea();
    }
}

