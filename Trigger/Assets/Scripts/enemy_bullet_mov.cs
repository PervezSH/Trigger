using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_mov : MonoBehaviour
{
    Rigidbody rb;
    bool moved;

    [SerializeField] float bullet_speed = 500f;
    [SerializeField] character_health get_health_info;
    [SerializeField] AudioSource aud_;
    private void Start()
    {
        get_health_info = get_player_health_script.instance.get_player.GetComponent<character_health>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        moved = false;
    }
    void Update()
    {
        if(moved == false)
        {
            do_move();
        }
    }
    void do_move()
    {
        rb.velocity = (Camera.main.transform.position - transform.position).normalized * bullet_speed * Time.deltaTime;
        moved = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            get_health_info.deduct_player_health();
            aud_.Play();
        }
    }
}
