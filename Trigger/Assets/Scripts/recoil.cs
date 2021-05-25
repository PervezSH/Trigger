using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class recoil : MonoBehaviour
{
    [SerializeField]
    float return_speed = 10f;
    [SerializeField] float mag_capacity = 2f;
    [SerializeField] float mag_capacity_for_particular_gun = 2f;
    [SerializeField] float reload_time = 1f;
    [SerializeField] float fire_rate = 25f;
    [SerializeField] float nxt_time_to_fire = 0f;

    [Header("Recoil Setting")]
    public Vector3 recoil_rotation = new Vector3(10f, 0f, 30f);
    public Vector3 recoil_position = new Vector3(-4.0f, 0f, 0f);

    Vector3 current_rotate;
    Vector3 current_pos;

    [Header("Audio")]
    [SerializeField]AudioSource audi;
    public AudioClip reload_sound;

    [Header("References")]
    [SerializeField] handle_attached_gun reloading_when_attach;

    [Header("Ammo")]
    [SerializeField] TextMeshProUGUI get_text;

    [Header("For Mobile Input")]
    [SerializeField] button_script get_button_to_click;
    [SerializeField] button_script get_reload_button_to_click;
    bool fired = false;
    bool reloading = false;
    private void Awake()
    {
        get_text.text = mag_capacity.ToString();
        reloading_when_attach = this.gameObject.GetComponentInParent<handle_attached_gun>();
        audi = this.gameObject.GetComponent<AudioSource>();
        if(this.gameObject.name == "AKM")
        {
            fire_rate = 7f;
        }
    }

    private void Update()
    {
        if(this.gameObject.name == "AKM")
        {
            if (get_button_to_click.Pressed && Time.time >= nxt_time_to_fire)       //Assault Firing
            {
                nxt_time_to_fire = Time.time + 1f / fire_rate;
                if (mag_capacity > 0)
                {
                    gun_recoil();
                    mag_capacity--;
                    get_text.text = mag_capacity.ToString();
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
                    gun_recoil();
                    mag_capacity--;
                    get_text.text = mag_capacity.ToString();
                }

            }
            if (fired && !get_button_to_click.Pressed)
            {
                fired = false;
            }
        }
        
        
        if (get_reload_button_to_click.Pressed && !reloading)     //Reload
        {
            reloading = true;
            audi.PlayOneShot(reload_sound);
            current_rotate += new Vector3(0f, 0f, 359f);
            Invoke("reload_gun", reload_time);
            reloading_when_attach.do_reload_when_attach = false;
        }
        if(reloading && !get_reload_button_to_click.Pressed)
        {
            reloading = false;
        }
        if (reloading_when_attach.do_reload_when_attach)
        {
            audi.PlayOneShot(reload_sound);
            current_rotate += new Vector3(0f, 0f, 359f);
            Invoke("reload_gun", reload_time);
            reloading_when_attach.do_reload_when_attach = false;
        }
    }
    void reload_gun()
    {
        mag_capacity = mag_capacity_for_particular_gun;
        get_text.text = mag_capacity.ToString();
    }
    void gun_recoil()
    {
        current_rotate += new Vector3(Random.Range(-recoil_rotation.x,recoil_rotation.x), -recoil_rotation.y, -recoil_rotation.z);
        current_pos += new Vector3(-recoil_position.x, -recoil_position.y, -recoil_position.z);
    }
    private void FixedUpdate()
    {
        current_rotate = Vector3.Lerp(current_rotate, Vector3.zero, return_speed *Time.deltaTime);
        current_pos = Vector3.Lerp(current_pos, Vector3.zero, return_speed * Time.deltaTime);
        
        transform.localRotation = Quaternion.Euler(current_rotate);
        transform.localPosition = current_pos;
    }
}
