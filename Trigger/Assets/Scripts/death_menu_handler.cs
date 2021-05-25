using UnityEngine;
using TMPro;
using System.Collections;

public class death_menu_handler : MonoBehaviour
{
    [SerializeField] Color pressed_color;
    [SerializeField] Color normal_color;

    [Header("UI Ref")]
    [SerializeField] GameObject death_menu;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject buttons_and_joystick;

    [Header("For Respawn Button")]
    [SerializeField] button_script respawn_button;
    [SerializeField] TextMeshProUGUI respawn_text;
    [SerializeField] TextMeshProUGUI ad_text;
    [SerializeField] character_health get_health;
    [SerializeField] TextMeshProUGUI respawn_timer_text;
    [SerializeField] Health_UI_handler get_health_regenarator;
    [SerializeField] TextMeshProUGUI get_timer;
    [SerializeField] AudioSource ticking_sound;


    //Hidden Properties
    private void Awake()
    {
        death_menu.SetActive(false);
        respawn_timer_text.enabled = false;
    }
    private void Update()
    {
        //For Respawn text color tint
        if (respawn_button.Pressed)
        {
            respawn_text.color = pressed_color;
            ad_text.color = pressed_color;
        }
        else
        {
            respawn_text.color = normal_color;
            ad_text.color = normal_color;
        }
    }
    public void do_when_death()
    {
        death_menu.SetActive(true);
        hud.SetActive(false);
        buttons_and_joystick.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void respawn_ad_watched()
    {
        get_health.respawning_to_true();                //give immortality
        get_health.Health = 100f;                       //set health
        hud.SetActive(true);                            //active hud
        get_timer.enabled = false;                      //Stop timer
        death_menu.SetActive(false);                    //deactive death menu
        buttons_and_joystick.SetActive(true);           //active button
        StartCoroutine(start_respwan_timer());
        Time.timeScale = 1.0f;
    }
    IEnumerator start_respwan_timer()
    {
        respawn_timer_text.enabled = true;
        int count = 3;
        while (count > 0)
        {
            respawn_timer_text.text = count.ToString();
            ticking_sound.Play();
            yield return new WaitForSeconds(1.0f);
            count--;
        }
        //Time.timeScale = 1.0f;
        get_timer.enabled = true;                       //start timer
        get_health.respawning_to_false();
        get_health_regenarator.health_regenarated();    //Remove blood on the screen
        get_health.play_healing_effect();               //play_healing_effect
        respawn_timer_text.enabled = false;
    }
}
