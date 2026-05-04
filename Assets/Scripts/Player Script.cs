
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{

    InputAction moveAction;
    InputAction jumpAction;

    States state;

    public Slider moldSlider;
    
    Rigidbody rb;
    public bool isGrounded;
    bool isMolding;
    bool isDead;
    bool isLaunching;

    [Range(0f, 5f)] float jumpPower = 0f;
    float launchPower = 50f;
    public float force = 10f;
    public static float Mold = 0f;
    float speed = 7.5f;

    //inputs
    bool isMoving;
    

    public enum States // used by all logic
    {
        None,
        Idle,
        Move,
        ChargedJump,
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>(); // gets the rigidbody
        state = States.Idle;    // Player always starts in idle

        isMolding = false;      // Cannot mold at the start

        Mold = 0f;              // Incase mold somehow carries over when the player dies

        moldSlider.value = Mold;
        moldSlider.maxValue = 100f;

        jumpAction = InputSystem.actions.FindAction("Jump");  // Finding the action in the Input System
        moveAction = InputSystem.actions.FindAction("Move");  // Finding the action in the Input System
    }

    
    public void FixedUpdate()
    {

        if (isLaunching)
        {
            Launch();
        }

        if(isMoving && state != States.ChargedJump)
        {
            state = States.Move;
        }
    }

    public void Update()
    {
        //read inputs and store in variables for FixedUpdate to read
        isMoving = moveAction.IsInProgress();

        if (isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Mold > 100f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (isMolding)     // If colliding with dirty ground start molding
        {
            Molding();
        }

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

        if (state == States.ChargedJump)
        {
            ChargedJump();
        }
    }

   public void Idle()
   {
        if (jumpAction.IsPressed() && isGrounded)
        {
            state = States.ChargedJump;
        }
   }

   public void PlayerMove()
   {
        // Vector3 vel;
        // float magnitude = rb.linearVelocity.magnitude;

        if (isMoving)
        {
            rb.AddForce(transform.forward * speed);//this must be called in FixedUpdate

           // vel = transform.forward * 10f;
           // rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
        }

        else
        {
            rb.AddForce(-transform.forward * speed * 0.1f);
           // vel = transform.forward * 0.1f;
           // rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
            state = States.Idle;
        }
   }

    public void ChargedJump()
    {

        if (jumpAction.IsInProgress() && isGrounded == true)  // Checkng if space is held
        {
            jumpPower += Time.deltaTime * 15f;

            if(jumpPower > 12f)
            {
               jumpPower = 12f;
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
            moldSlider.value = Mold;
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

    public void RemoveMold()
    {
        Mold = Mold - 30f;
        moldSlider.value = Mold; // Gets the Players mold from PlayerScript and takes away 30 from it when picking up the powerup

        if(Mold < 0)                                           // Prevents Mold from being negative 
        {
           Mold = 0;
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

        if (col.gameObject.tag == "Vinegar")
        {
            RemoveMold();
            print("Picked Up Bottle");
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

