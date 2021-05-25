using UnityEngine;

public class Slow_mo_prop : MonoBehaviour
{
    [SerializeField] save_and_load_manager_for_game_items get_game_item_script;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            get_game_item_script.stopwatch++;
            AudioSource this_game_adu_s = this.gameObject.GetComponent<AudioSource>();
            this_game_adu_s.Play();
            Destroy(this.gameObject,0.5f);
        }
    }
}
