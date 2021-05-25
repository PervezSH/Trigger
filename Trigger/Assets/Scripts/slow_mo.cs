using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class slow_mo : MonoBehaviour
{
    [SerializeField] button_script get_slow_mo_button_to_click;
    [SerializeField] TextMeshProUGUI get_the_times;
    [SerializeField] AudioSource get_slow_mo_sound;
    [SerializeField] Image get_the_button_image;
    [SerializeField] Canvas get_the_canvas;
    [SerializeField] Slider get_the_slider;
    [SerializeField] GameObject buy_watch_ad_menu;
    [SerializeField] buy_watch_ad_menu_handler get_the_buywatchad_script;
    [SerializeField] save_and_load_manager_for_game_items get_game_item_script;

    [Header("Values")]
    [SerializeField] float max_slow_time = 30f;
    [SerializeField] Color reduced_alpha;
    [SerializeField] Color org_alpha;

    

    float timer = 0.0f;
    bool slow_mo_button_pressed;
    bool slow_mo_started;
    bool ad_enabled;
    int s_per = 1;
    private void Start()
    {
        ad_enabled = true;
        buy_watch_ad_menu.SetActive(false);
        timer = max_slow_time;
        get_the_times.text = get_game_item_script.stopwatch.ToString();
        slow_mo_button_pressed = false;
        slow_mo_started = false;
        get_the_canvas.enabled = false;
    }
    private void Update()
    {
        if(get_game_item_script.stopwatch > 0)
        {
            if (get_slow_mo_button_to_click.Pressed && !slow_mo_button_pressed && !slow_mo_started)
            {
                slow_mo_button_pressed = true;
                slow_mo_started = true;
                get_the_button_image.color = reduced_alpha;
                Invoke("set_slow_started_to_false", 7f);
                count_time();
                get_game_item_script.stopwatch--;
                get_slow_mo_sound.Play();

                // slow mo slider
                get_the_canvas.enabled = true;
                change_slider();
            }
            if(!get_slow_mo_button_to_click.Pressed && slow_mo_button_pressed)
            {
                slow_mo_button_pressed = false;
            }
            ad_enabled = false;             //trigger false to show add
        }
        else
        {
            if(get_slow_mo_button_to_click.Pressed && ad_enabled)
            {
                buy_watch_ad_menu.SetActive(true);
                get_the_buywatchad_script.set_add_slow_mo_to_true();
                Time.timeScale = 0.0f;
            }
        }
        get_the_times.text = get_game_item_script.stopwatch.ToString();
    }
    void count_time()
    {
        if (timer > 0)
        {
            timer--;
            Time.timeScale = 0.2f;
            Invoke("count_time", 1.0f);
        }
        else
        {
            Time.timeScale = 1.0f;
            Invoke("reset_timer", 5.0f);
        }
    }
    void reset_timer()
    {
        timer = max_slow_time;
    }
    void set_slow_started_to_false ()
    {
        slow_mo_started = false;
        get_the_button_image.color = org_alpha;

        if(get_game_item_script.stopwatch == 0)                         //trigger true to show add
        {
            ad_enabled = true;
        }
    }
    void change_slider()
    {
        if(s_per == 100)
        {
            get_the_canvas.enabled = false;
            get_the_slider.value = 100;
            s_per = 1;
        }
        else
        {
            get_the_slider.value = 100 - s_per;
            s_per = s_per + 1;
            Invoke("change_slider", 0.02f);
        }
    }
}
