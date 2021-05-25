using UnityEngine;

public class Health_prop : MonoBehaviour
{

    [SerializeField] character_health get_character_health_to_change;
    [SerializeField] Health_UI_handler get_ui_blood_effect_to_change;
    [SerializeField] save_and_load_manager_for_game_items get_game_item_script;

    private void OnTriggerEnter(Collider other)
    {
        if(get_character_health_to_change.Health < 100)
        {
            if (other.tag == "Player")
            {
                get_character_health_to_change.Health = 100f;
                get_character_health_to_change.play_healing_effect();
                get_ui_blood_effect_to_change.health_regenarated();
                Destroy(this.gameObject);
            }
        }
        else
        {
            get_game_item_script.heath++;
            AudioSource this_game_aud_s = this.gameObject.GetComponent<AudioSource>();
            this_game_aud_s.Play();
            Destroy(this.gameObject,0.5f);
        }
    }
}
