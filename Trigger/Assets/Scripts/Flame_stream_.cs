using UnityEngine;

public class Flame_stream_ : MonoBehaviour
{
    
    void Update()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.up,out hit, 5.0f))
        {
            if(hit.transform.tag == "Player")
            {
                character_health get_character_health = hit.transform.gameObject.GetComponent<character_health>();
                get_character_health.deduct_health_due_to_flame_thrower();
            }
        }
    }
    
}
