using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int total_time = 100;
    [SerializeField] TextMeshProUGUI get_timer_text;

    [SerializeField] Color pressed_color;
    [SerializeField] Color normal_color;

    [Header("UI Ref")]
    [SerializeField] GameObject time_out_menu;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject buttons_and_joystick;

    [Header("For Add time Button")]
    [SerializeField] button_script add_time_button;
    [SerializeField] TextMeshProUGUI add_time_text;
    [SerializeField] TextMeshProUGUI ad_text;
    [SerializeField] TextMeshProUGUI respawn_timer_text;
    [SerializeField] Image slow_mo_button;
    [SerializeField] AudioSource ticking_sound;
    [SerializeField] pause_menu_handler get_pause_menu_script;

    //hidden Properties
    bool time_out_;
    public float current_timer_timescale;
    private void Start()
    {
        reduce_time();
        get_timer_text.text = total_time.ToString();
        time_out_menu.SetActive(false);
        time_out_ = false;
        respawn_timer_text.enabled = false;
    }
    private void Update()
    {
        if(total_time <= 0 && !time_out_)
        {
            do_when_time_out();
            time_out_ = true;
        }
        if(time_out_ && total_time > 0)
        {
            time_out_ = false;
        }
        //For Respawn text color tint
        if (add_time_button.Pressed)
        {
            add_time_text.color = pressed_color;
            ad_text.color = pressed_color;
        }
        else
        {
            add_time_text.color = normal_color;
            ad_text.color = normal_color;
        }
    }
    void reduce_time()
    {
        total_time--;
        get_timer_text.text = total_time.ToString();
        if(total_time < 0)
        {
            get_timer_text.text = " ";
        }
        Invoke("reduce_time", 1.0f);
    }
    void do_when_time_out()
    {
        time_out_menu.SetActive(true);
        hud.SetActive(false);
        buttons_and_joystick.SetActive(false);
        current_timer_timescale = Time.timeScale;
        Time.timeScale = 0.0f;
    }
    public void add_time_ad_watched()
    {
        get_pause_menu_script.set_adding_time_to_true();
        time_out_menu.SetActive(false);
        hud.SetActive(true);
        buttons_and_joystick.SetActive(true);
        slow_mo_button.enabled = false;
        get_timer_text.enabled = false;
        StartCoroutine(start_respwan_timer());
    }
    IEnumerator start_respwan_timer()
    {
        respawn_timer_text.enabled = true;
        int count = 3;
        while (count > 0)
        {
            respawn_timer_text.text = count.ToString();
            ticking_sound.Play();
            yield return new WaitForSecondsRealtime(1.0f);
            count--;
        }
        total_time = 30;
        Time.timeScale = current_timer_timescale;
        get_pause_menu_script.set_adding_time_to_false();
        slow_mo_button.enabled = true;
        respawn_timer_text.enabled = false;
        get_timer_text.enabled = true;
    }
}
