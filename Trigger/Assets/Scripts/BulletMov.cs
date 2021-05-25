using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    [SerializeField] float bullet_speed = 100f;
    Vector3 hit_point = new Vector3(0f, 0f, 0f);

    Rigidbody rb;
    [SerializeField] GameObject ref_cam;
    private void Start()
    {
        transform.parent = null;
        rb = this.gameObject.GetComponent<Rigidbody>();
        ref_cam = get_main_cam.instance.get_camera;

        RaycastHit hit;
        Ray ray_ = new Ray(ref_cam.transform.position, ref_cam.transform.forward);
        if(Physics.Raycast(ray_,out hit))
        {
            hit_point = hit.point;
            if(hit.transform.name == "yBot")
            {
                AI_Enemy get_enemy_ref = hit.transform.GetComponent<AI_Enemy>();
                get_enemy_ref.deduct_enemy_health();
            }
            if(hit.transform.tag == "Explosive")
            {
                Barrel_explode get_barrel_ = hit.transform.GetComponent<Barrel_explode>();
                get_barrel_.on_hitting();
            }
        }
        else
        {
            hit_point = ray_.GetPoint(50);
        }
        
    }
    void Update()
    {
        rb.velocity = (hit_point - transform.position).normalized * bullet_speed * Time.deltaTime;
        Destroy(this.gameObject,0.75f);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
