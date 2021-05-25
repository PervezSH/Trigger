using UnityEngine;
using TMPro;

public class buy_watch_ad_menu_handler : MonoBehaviour
{
    [SerializeField] Color pressed_color;
    [SerializeField] Color normal_color;

    [SerializeField] GameObject buy_watch_ad_menu;
    [SerializeField] character_health get_the_character_health_script;
    [SerializeField] save_and_load_manager_for_game_items get_game_item_script;

    [Header("UI Ref")]
    [SerializeField] GameObject hud;
    [SerializeField] GameObject buttons_and_joysticks;

    [Header("For Blur Image")]
    [SerializeField] button_script blur_image_button;
    bool blur_image_pressed;

    [Header("For Buy Button")]
    [SerializeField] button_script buy_button;
    [SerializeField] TextMeshProUGUI buy_button_text;
    [SerializeField] GameObject extra_menu;

    [Header("For WatchAdd Button")]
    [SerializeField] button_script watch_add_button;
    [SerializeField] TextMeshProUGUI watch_add_button_text;

    public bool add_health;
    bool add_slow_mo;
    private void Start()
    {
        blur_image_pressed = false;
        add_health = false;
        add_slow_mo = false;
    }

    private void Update()
    {
        //For Blur image
        if (blur_image_button.Pressed && !blur_image_pressed)
        {
            buy_watch_ad_menu.SetActive(false);
            if (add_health)
            {
                Time.timeScale = get_the_character_health_script.timescale_before_refil_health_clicked;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
            blur_image_pressed = true;
        }
        if(!blur_image_button.Pressed && blur_image_pressed)
        {
            blur_image_pressed = false;
        }

        //For Buy text color tint
        if (buy_button.Pressed)
        {
            buy_button_text.color = pressed_color;
        }
        else
        {
            buy_button_text.color = normal_color;
        }

        //For Watch Add text color tint
        if (watch_add_button.Pressed)
        {
            watch_add_button_text.color = pressed_color;
        }
        else
        {
            watch_add_button_text.color = normal_color;
        }
    }
    public void buy_button_clicked()
    {
        buy_watch_ad_menu.SetActive(false);
        hud.SetActive(false);
        buttons_and_joysticks.SetActive(false);
        extra_menu.SetActive(true);
    }
    public void give_the_rewards_ad_watched()
    {
        if (add_slow_mo)
        {
            get_game_item_script.stopwatch++;
            add_slow_mo = false;
            Time.timeScale = 1.0f;
            buy_watch_ad_menu.SetActive(false);
        }
        if (add_health)
        {
            get_game_item_script.heath++;
            add_health = false;
            Time.timeScale = get_the_character_health_script.timescale_before_refil_health_clicked;
            buy_watch_ad_menu.SetActive(false);
        }
    }
    public void set_add_health_to_true()
    {
        add_health = true;
    }
    public void set_add_slow_mo_to_true()
    {
        add_slow_mo = true;
    }
}
