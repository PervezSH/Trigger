using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_recoil : MonoBehaviour
{
    [SerializeField]
    float return_speed = 10f;
    [SerializeField] float mag_capacity = 5f;
    [SerializeField] float mag_capacity_accrnding_to_attached_gun;
    [SerializeField] float reload_time = 1f;
    [SerializeField] float nxt_time_to_fire = 0f;
    [SerializeField] float fire_rate = 15f;

    [Header("Recoil Setting")]
    [SerializeField]
    Vector3 recoil_rotation = new Vector3(10f, 0f, 0f);
    Vector3 current_rotate;

    [Header("Reference")]
    [SerializeField] Transform for_getting_attached_gun;
    [SerializeField] GameObject attached_gun;

    private void Awake()
    {
        attached_gun = for_getting_attached_gun.transform.GetChild(0).gameObject;
        if (attached_gun.name == "Remington 870")
        {
            mag_capacity_accrnding_to_attached_gun = 2f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
            return_speed = 5f;
            recoil_rotation.x = 10f;
        }
        if(attached_gun.name == "M1911")
        {
            mag_capacity_accrnding_to_attached_gun = 7f;
        }
        if (attached_gun.name == "AKM")
        {
            mag_capacity_accrnding_to_attached_gun = 30f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
            return_speed = 15f;
            recoil_rotation.x = 1.5f;
            fire_rate = 7f;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Invoke("set_again", 0.05f);
        }
        if(attached_gun.name == "AKM")
        {
            if (Input.GetButton("Fire1") && Time.time >= nxt_time_to_fire)
            {
                nxt_time_to_fire = Time.time + 1f / fire_rate;
                if (mag_capacity > 0)
                {
                    gun_recoil();
                    mag_capacity--;
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (mag_capacity > 0)
                {
                    gun_recoil();
                    mag_capacity--;
                }
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("reload_gun", reload_time);
        }
    }
    void reload_gun()
    {
        mag_capacity = mag_capacity_accrnding_to_attached_gun;
    }
    void gun_recoil()
    {
        current_rotate += new Vector3(-recoil_rotation.x, -recoil_rotation.y, Random.Range(-recoil_rotation.z, recoil_rotation.z));
    }
    private void FixedUpdate()
    {
        current_rotate = Vector3.Lerp(current_rotate, Vector3.zero, return_speed * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(current_rotate);
    }
    void set_again()
    {
        attached_gun = for_getting_attached_gun.transform.GetChild(0).gameObject;
        if (attached_gun.name == "Remington 870")
        {
            mag_capacity_accrnding_to_attached_gun = 2f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
            return_speed = 5f;
            recoil_rotation.x = 10f;
        }
        if (attached_gun.name == "M1911")
        {
            mag_capacity_accrnding_to_attached_gun = 7f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
        }
        if (attached_gun.name == "AKM")
        {
            mag_capacity_accrnding_to_attached_gun = 30f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
            return_speed = 15f;
            recoil_rotation.x = 1.5f;
            fire_rate = 7f;
        }
    }
}
