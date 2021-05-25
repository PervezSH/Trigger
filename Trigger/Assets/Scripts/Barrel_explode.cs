using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_explode : MonoBehaviour
{
    [SerializeField] int total_gameobject; //no. of gameobject that would get damage due to explosion
    [SerializeField] GameObject[] get_the_gameobject;
    [SerializeField] float[] distance_between;

    
    private void Update()
    {
        for(int i = 0; i < total_gameobject; i++)
        {
            distance_between[i] = Vector3.Distance(transform.position, get_the_gameobject[i].transform.position);
        }
    }
    
    public void on_hitting()
    {
        ParticleSystem get_barrel_explosion = this.gameObject.GetComponentInChildren<ParticleSystem>();
        MeshRenderer get_graphics = this.gameObject.GetComponent<MeshRenderer>();
        CapsuleCollider get_collider = this.gameObject.GetComponent<CapsuleCollider>();
        AudioSource aud_ = this.gameObject.GetComponent<AudioSource>();
        get_graphics.enabled = false;
        aud_.Play();
        get_barrel_explosion.Play();
        get_collider.enabled = false;
        do_damage();

        Destroy(this.gameObject, 5f);
    }
    void do_damage()
    {
        for(int i = 0; i < total_gameobject; i++)
        {
            if (distance_between[i] <= 9)
            {
                float damage_to_deal;
                if (distance_between[i] < 4)
                {
                    damage_to_deal = 100f;
                    damage_by_explosive get_the_script_to_do_damage = get_the_gameobject[i].GetComponent<damage_by_explosive>();
                    get_the_script_to_do_damage.do_explosive_damage(damage_to_deal);
                }
                else
                {
                    damage_to_deal = 100f - distance_between[i] * 10f;
                    damage_by_explosive get_the_script_to_do_damage = get_the_gameobject[i].GetComponent<damage_by_explosive>();
                    get_the_script_to_do_damage.do_explosive_damage(damage_to_deal);
                }
            }
        }
    }
}
