using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fire_range;
    [SerializeField] float mag_capacity;
    [SerializeField] float reload_time = 1f;
    float mag_capacity_accrnding_to_attached_gun;
    [SerializeField] float nxt_time_to_fire = 0f;
    [SerializeField] float fire_rate = 25f;

    [Header("Assignments:")]
    [SerializeField] GameObject fps_cam;
    [SerializeField]
    ParticleSystem muzzle_flash;
    [SerializeField]
    AudioSource aud;
    [SerializeField] GameObject impactEffect;
    [SerializeField] GameObject impactEffectBlood;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject attached_gun;
    [SerializeField] Transform instantiate_pos;

    [Header("For Mobile Input")]
    [SerializeField] button_script get_button_to_click;
    [SerializeField] button_script get_swap_button_to_click;
    [SerializeField] button_script get_reload_button_to_click;
    bool fired = false;
    bool gun_changed = false;
    bool reloading = false;

    private void Awake()
    {
        muzzle_flash = this.gameObject.GetComponentInChildren<ParticleSystem>();
        aud = this.gameObject.GetComponentInChildren<AudioSource>();
        attached_gun = this.gameObject.transform.GetChild(0).gameObject;
        instantiate_pos = attached_gun.transform.Find("instantiate_pos").transform;
        if(attached_gun.name == "Remington 870")
        {
            mag_capacity_accrnding_to_attached_gun = 2f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
        }
        if(attached_gun.name== "M1911")
        {
            mag_capacity_accrnding_to_attached_gun = 7f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
        }
        if (attached_gun.name == "AKM")
        {
            mag_capacity_accrnding_to_attached_gun = 30f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
            fire_rate = 7f;
        }
    }

    void Update()
    {
        if (get_swap_button_to_click.Pressed && !gun_changed)       //Swap button
        {
            gun_changed = true;
            Invoke("set_again", 0.16f);
        }
        if(gun_changed && !get_swap_button_to_click.Pressed)
        {
            gun_changed = false;
        }
        if(attached_gun.name == "AKM")
        {
            if (get_button_to_click.Pressed && Time.time >= nxt_time_to_fire)       //Assault_Firing
            {
                nxt_time_to_fire = Time.time + 1f / fire_rate;
                if (mag_capacity > 0)
                {
                    mag_capacity--;
                    shoot();
                    GameObject bulletGo = Instantiate(bullet, instantiate_pos);
                    Destroy(bulletGo, 2f);
                }

            }
        }
        else
        {
            if (get_button_to_click.Pressed && !fired)      //Firing
            {
                fired = true;
                if (mag_capacity > 0)
                {
                    mag_capacity--;
                    shoot();
                    GameObject bulletGo = Instantiate(bullet, instantiate_pos);
                    Destroy(bulletGo, 2f);
                }

            }
            if(fired && !get_button_to_click.Pressed)
            {
                fired = false;
            }
        }
        
        
        if (get_reload_button_to_click.Pressed && !reloading)        //Reload
        {
            reloading = true;
            Invoke("reload_ammo", reload_time);
        }
        if(!get_reload_button_to_click.Pressed && reloading)
        {
            reloading = false;
        }
    }
    void reload_ammo()
    {
        mag_capacity = mag_capacity_accrnding_to_attached_gun;
    }
    void shoot()
    {
        aud.Play();
        muzzle_flash.Play();
        

        RaycastHit hit;
        if(Physics.Raycast(fps_cam.transform.position,fps_cam.transform.forward,out hit, fire_range))
        {
            
            if(hit.collider.tag == "Enemy")
            {
                GameObject impactGo = Instantiate(impactEffectBlood, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 2f);
            }
            else
            {
                GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 5f);
            }
        }
    }
    void set_again()
    {
        muzzle_flash = this.gameObject.GetComponentInChildren<ParticleSystem>();
        aud = this.gameObject.GetComponentInChildren<AudioSource>();
        attached_gun = this.gameObject.transform.GetChild(0).gameObject;
        instantiate_pos = attached_gun.transform.Find("instantiate_pos").transform;
        if (attached_gun.name == "Remington 870")
        {
            mag_capacity_accrnding_to_attached_gun = 2f;
            mag_capacity = mag_capacity_accrnding_to_attached_gun;
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
            fire_rate = 7f;
        }
    }
}
