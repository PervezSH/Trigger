using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle_enemy_gun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool detach_gun;
    [SerializeField] bool gun_detached;
    [SerializeField] GameObject attached_gun;

    [Header("Weapons to throw :")]
    [SerializeField] GameObject gun;
    
    
    void Start()
    {
        detach_gun = false;
        gun_detached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(detach_gun == true && gun_detached == false)
        {
            attached_gun = this.transform.GetChild(5).gameObject;
            if(attached_gun.name == "M1911_atEnemy")
            {
                Invoke("detach_and_throw_gun", 0.3f);
                gun_detached = true;
                Destroy(attached_gun,0.5f);
                
            }
        }
    }

    public void set_detach_gun_true()
    {
        detach_gun = true;
    }
    public void set_detach_gun_false()
    {
        detach_gun = false;
    }
    void detach_and_throw_gun()
    {
        Instantiate(gun, attached_gun.transform.position, attached_gun.transform.rotation);
    }
}
