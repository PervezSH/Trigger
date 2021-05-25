using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle_attached_gun : MonoBehaviour
{
    [SerializeField] float gun_attaching_speed = 2000f;
    [SerializeField] GameObject gun_to_throw;
    [SerializeField] GameObject gun_to_attached;
    [SerializeField] GameObject[] gun = new GameObject[3];
    public bool do_reload_when_attach;

    [Header("Weapons")]
    [SerializeField] GameObject Pistol;
    [SerializeField] GameObject Shootgun;
    [SerializeField] GameObject Rifle;
    [SerializeField] Rigidbody get_gun_rb;
    [SerializeField] Transform instntiate_posi;

    [Header("For Mobile Input")]
    [SerializeField] button_script get_swap_button_to_click;
    bool gun_changed = false;

    private void Awake()
    {
        do_reload_when_attach = false;
        gun[0] = this.gameObject.transform.GetChild(0).gameObject;
        gun[1] = this.gameObject.transform.GetChild(1).gameObject;
        gun[2] = this.gameObject.transform.GetChild(2).gameObject;
    }
    private void Update()
    {
        if (get_swap_button_to_click.Pressed && !gun_changed)
        {
            gun_changed = true;
            get_gun_info();
        }
        if(gun_changed && !get_swap_button_to_click.Pressed)
        {
            gun_changed = false;
        }
    }
    void get_gun_info()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 5f))
        {
           if(hit.collider.name == "AKM_scattered" || hit.collider.name == "AKM_scattered(Clone)")
            {
                Invoke("set_again", 0.16f);
                for(int i = 0; i < 3; i++)
                {
                    if (gun[i].name == "AKM")
                    {
                        check_gun();
                        detach_gun(gun_to_throw);
                        gun[0].transform.gameObject.SetActive(false);
                        gun[i].transform.SetSiblingIndex(0);
                        move_towards();
                        gun_to_attached = gun[i].transform.gameObject;
                        Invoke("change_gun", 0.15f);
                    }
                }
            }
            if (hit.collider.name == "M1911_scattered" || hit.collider.name == "M1911_scattered(Clone)")
            {
                Invoke("set_again", 0.16f);
                for (int i = 0; i < 3; i++)
                {
                    if (gun[i].name == "M1911")
                    {
                        check_gun();
                        detach_gun(gun_to_throw);
                        gun[0].transform.gameObject.SetActive(false);
                        gun[i].transform.SetSiblingIndex(0);
                        move_towards();
                        gun_to_attached = gun[i].transform.gameObject;
                        Invoke("change_gun", 0.15f);
                    }
                }
            }
            if (hit.collider.name == "Remington 870_scattered" || hit.collider.name == "Remington 870_scattered(Clone)")
            {
                Invoke("set_again", 0.16f);
                for (int i = 0; i < 3; i++)
                {
                    if (gun[i].name == "Remington 870")
                    {
                        check_gun();
                        detach_gun(gun_to_throw);
                        gun[0].transform.gameObject.SetActive(false);
                        gun[i].transform.SetSiblingIndex(0);
                        move_towards();
                        gun_to_attached = gun[i].transform.gameObject;
                        Invoke("change_gun", 0.15f);
                    }
                }
            }
            void detach_gun(GameObject gun_to_detach)
            {
                GameObject clone = Instantiate(gun_to_detach, instntiate_posi.position, instntiate_posi.rotation);
                Rigidbody rb = clone.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(Camera.main.transform.forward * 30f, ForceMode.Impulse);
                rb.AddForce(Camera.main.transform.up * 20f, ForceMode.Impulse);
            }
            void check_gun()
            {
                if(gun[0].name == "M1911")
                {
                    gun_to_throw = Pistol;
                }
                if (gun[0].name == "AKM")
                {
                    gun_to_throw = Rifle;
                }
                if (gun[0].name == "Remington 870")
                {
                    gun_to_throw = Shootgun;
                }
            }
        }
        void move_towards()
        {
            get_gun_rb = hit.transform.GetComponent<Rigidbody>();
            get_gun_rb.velocity = (gun[0].transform.position - get_gun_rb.transform.position).normalized * gun_attaching_speed * Time.deltaTime;
            Destroy(hit.transform.gameObject,0.15f);
        }
    }
    void set_again()
    {
        //do_reload_when_attach = false;
        gun[0] = this.gameObject.transform.GetChild(0).gameObject;
        gun[1] = this.gameObject.transform.GetChild(1).gameObject;
        gun[2] = this.gameObject.transform.GetChild(2).gameObject;
    }
    void change_gun()
    {
        gun_to_attached.transform.gameObject.SetActive(true);
        do_reload_when_attach = true;
    }
}
