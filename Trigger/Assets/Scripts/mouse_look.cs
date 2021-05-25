using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouse_look : MonoBehaviour
{
    public float Mouse_Sensitivity = 10f;
    public Transform Player;
    float xRotation = 0.0f;
    public float upAngle;
    public float downAngle;

    float xMouse;
    float yMouse;

    bool on_wall;
    Quaternion xRot;
    float camera_tilt_angle;
    [SerializeField] float tilt_angle = 15f;

    [Header("For Mobile Input")]
    [SerializeField] FixedTouchField get_touch;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        on_wall = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*xMouse = Input.GetAxis("Mouse X") * Mouse_Sensitivity * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * Mouse_Sensitivity * Time.deltaTime;*/

        //Mobile Input
        xMouse = get_touch.TouchDist.x * Mouse_Sensitivity * Time.unscaledDeltaTime;
        yMouse = get_touch.TouchDist.y * Mouse_Sensitivity * Time.unscaledDeltaTime;

        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, upAngle, downAngle);

        if (on_wall)
        {
            tilting_while_on_wall();
        }
        else
        {
            xRot = Quaternion.Lerp(Quaternion.Euler(xRotation, 0f, camera_tilt_angle),Quaternion.Euler(xRotation, 0.0f, 0.0f), 0.5f*Time.time);
        }

        transform.localRotation = xRot;
        Player.Rotate(Vector3.up * xMouse);
    }
    public void set_on_wall_true()
    {
        on_wall = true;
    }
    public void set_on_wall_false()
    {
        on_wall = false;
    }
    void tilting_while_on_wall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, 1f))
        {
            if (hit.transform.tag == "Walkable_wall")
            {
                camera_tilt_angle = tilt_angle;
            }
        }
        RaycastHit hit1;
        if (Physics.Raycast(transform.position, -transform.right, out hit1, 1f))
        {
            if (hit1.transform.tag == "Walkable_wall")
            {
                camera_tilt_angle = -tilt_angle;
            }
        }
        xRot = Quaternion.Lerp(Quaternion.Euler(xRotation, 0.0f, 0.0f), Quaternion.Euler(xRotation, 0f, camera_tilt_angle), 0.5f*Time.time);
    }
}
