using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    
    CharacterController c;
    public float move_speed = 100f;
    public float gravity = -9.81f;
    [SerializeField]
    Vector3 velocity;
    public float jump_height = 2f;
    public float slope_force = 10f;
    float x, y;
    Vector3 move;

    [SerializeField] float Speed;

    //Wall Movement
    bool fall_down;
    [SerializeField] mouse_look get_camere_look_script;

    [Header("For Mobile Input")]
    [SerializeField] Joystick joys_;
    [SerializeField] button_script get_jump_button;
    private void Awake()
    {
        fall_down = false;
        c = this.gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        
        //Movement.....
        if (c.isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, c.height))
            {
                if (hit.normal != Vector3.up)
                {
                    velocity.y = velocity.y * slope_force;
                }
            }
        }

        if (c.isGrounded)
        {
            //For PC Movement
            /*x = Input.GetAxis("Horizontal") * Time.deltaTime;
            y = Input.GetAxis("Vertical") * Time.deltaTime;*/

            x = joys_.Horizontal * Time.deltaTime;
            y = joys_.Vertical * Time.deltaTime;

            move = transform.right * x + transform.forward * y;

        }
        else
        {
            get_camere_look_script.set_on_wall_false();
        }

        

        if (get_jump_button.Pressed && c.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }
        
        velocity.y += gravity*Time.deltaTime;
        
        c.Move(move * move_speed * Time.deltaTime);
        c.Move(velocity * Time.deltaTime);
        
        Speed = move.magnitude * move_speed;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Walkable_wall" && Speed >= 7.4f)
        {
            velocity.y = 0.0f;      //set gravity zero so that it can stick to the wall
            get_camere_look_script.set_on_wall_true();

            if (get_jump_button.Pressed)
            {
                velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
                
                //For PC input
                /*x = Input.GetAxis("Horizontal") * Time.deltaTime;
                y = Input.GetAxis("Vertical") * Time.deltaTime;*/

                x = joys_.Horizontal * Time.deltaTime;
                y = joys_.Vertical * Time.deltaTime;
                move = transform.right * x + transform.forward * y;
                c.Move(move * move_speed * Time.deltaTime);

                if (joys_.Vertical == 1.0f)
                {
                    fall_down = false;
                }
                else
                {
                    fall_down = true;
                }
            }
        }
    }
    
}
