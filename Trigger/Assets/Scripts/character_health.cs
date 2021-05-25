using UnityEngine;
using TMPro;

public class character_health : MonoBehaviour
{
    public float Health = 100f;
    [SerializeField] float deduct_per_hit = 10f;
    [SerializeField] Health_UI_handler control_health_related_ui;

    [Header("Healing Effect")]
    [SerializeField] ParticleSystem get_healing_p_s;
    [SerializeField] AudioSource get_heal_sound_effect;

    [Header("For Explosive Damage")]
    [SerializeField] damage_by_explosive get_damage;

    [Header("For Fire Damage")]
    bool do_fire_damage;
    [SerializeField] float fire_damage_rate = 1f;

    [Header("For Death Menu")]
    [SerializeField] death_menu_handler death_menu;
    bool death;
    bool respawning;

    [Header("For Health Refil")]
    //public int refil_time;
    [SerializeField] save_and_load_manager_for_game_items get_game_item_script;
    [SerializeField] TextMeshProUGUI refill_times_text;
    [SerializeField] Health_UI_handler get_ui_blood_effect_to_change;
    [SerializeField] GameObject buy_watch_ad_menu;
    [SerializeField] buy_watch_ad_menu_handler get_the_buywatchad_script;

    public float timescale_before_refil_health_clicked;
    private void Awake()
    {
        get_damage = this.gameObject.GetComponent<damage_by_explosive>();
        do_fire_damage = false;
        death = false;
        respawning = false;
    }
    private void Update()
    {
        refill_times_text.text = get_game_item_script.heath.ToString();
        if (Health <= 0 && !death)
        {
            death = true;
            death_menu.do_when_death();
        }
        if(death && Health > 0)
        {
            death = false;
        }
        if (get_damage.explosive_triggered)
        {
            do_damage_explosive_();
            get_damage.set_trigger_for_explosive_false();
        }
    }
    public void deduct_player_health()
    {
        if (!respawning)
        {
            Health = Health - deduct_per_hit;
            control_health_related_ui.do_blood_flashing(0.075f);
        }
    }
    public void play_healing_effect()
    {
        get_healing_p_s.Play();
        get_heal_sound_effect.Play();
    }
    void do_damage_explosive_()
    {
        if (!respawning)
        {
            Health = Health - get_damage.amount_of_damage_done_by_explosive - 20f;
            control_health_related_ui.do_explosive_blood_flashing(100f - Health);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Fire")
        {
            deduct_health_due_to_fire();
        }
    }
    void deduct_health_due_to_fire()
    {
        if (!respawning)
        {
            Health = Health - fire_damage_rate;
            control_health_related_ui.do_blood_flashing(0.005f);
        }
    }
    public void deduct_health_due_to_flame_thrower()
    {
        if (!respawning)
        {
            Health = Health - 5.0f;
            control_health_related_ui.do_blood_flashing(0.03f);
        }
    }
    public void respawning_to_false()
    {
        respawning = false;
    }
    public void respawning_to_true()
    {
        respawning = true;
    }
    public void refill_health_button_clicked()
    {
        if (get_game_item_script.heath > 0)
        {
            Health = 100f;
            play_healing_effect();
            get_ui_blood_effect_to_change.health_regenarated();
            get_game_item_script.heath--;
        }
        else
        {
            buy_watch_ad_menu.SetActive(true);
            get_the_buywatchad_script.set_add_health_to_true();
            timescale_before_refil_health_clicked = Time.timeScale;
            Time.timeScale = 0.0f;
        }
    }
}
