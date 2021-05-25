using UnityEngine;
using TMPro;
using System.Collections;
public class extra_menu_handler : MonoBehaviour
{
    [SerializeField] Color pressed_color;
    [SerializeField] Color normal_color;
    [SerializeField] TextMeshProUGUI not_enough_star_txt;

    [Header("UI Ref")]
    [SerializeField] GameObject extra_menu;
    [SerializeField] GameObject pause_menu;
    [SerializeField] GameObject buttons_and_joy;
    [SerializeField] GameObject hud;

    [Header("For Items Available Number")]
    [SerializeField] save_and_load_manager_for_game_items get_game_item_script;
    [SerializeField] TextMeshProUGUI star_no;
    [SerializeField] TextMeshProUGUI health_no;
    [SerializeField] TextMeshProUGUI slow_mo_no;

    [Header("For Back Button")]
    [SerializeField] button_script back_button;
    [SerializeField] TextMeshProUGUI back_text;
    [SerializeField] character_health get_the_timescale;
    [SerializeField] buy_watch_ad_menu_handler get_the_bool;

    bool pause_menu_active;

    private void Start()
    {
        pause_menu_active = false;
        not_enough_star_txt.enabled = false;
    }

    private void Update()
    {
        //Updating Items Quantity
        star_no.text = get_game_item_script.star.ToString();
        health_no.text = get_game_item_script.heath.ToString();
        slow_mo_no.text = get_game_item_script.stopwatch.ToString();
        
        //For Back text color tint
        if (back_button.Pressed)
        {
            back_text.color = pressed_color;
        }
        else
        {
            back_text.color = normal_color;
        }
    }
    public void on_extra_menu_back_button_clicked()
    {
        if (pause_menu_active)
        {
            extra_menu.SetActive(false);
            pause_menu.SetActive(true);
            pause_menu_active = false;
        }
        else
        {
            extra_menu.SetActive(false);
            hud.SetActive(true);
            buttons_and_joy.SetActive(true);
            if (get_the_bool.add_health)
            {
                Time.timeScale = get_the_timescale.timescale_before_refil_health_clicked;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
    public void set_pause_menu_active_to_true()
    {
        pause_menu_active = true;
    }
    //Related to Buying
    //Star
    public void on_1_dollar_10_star_clicked()
    {
        get_game_item_script.star = get_game_item_script.star + 10;
    }
    public void on_2_dollar_25_star_clicked()
    {
        get_game_item_script.star = get_game_item_script.star + 25;
    }
    public void on_5_dollar_60_star_clicked()
    {
        get_game_item_script.star = get_game_item_script.star + 60;
    }
    //Health
    public void on_10_star_3_health_clicked()
    {
        if (get_game_item_script.star-10 >= 0)
        {
            get_game_item_script.heath = get_game_item_script.heath + 3;
            get_game_item_script.star = get_game_item_script.star - 10;
        }
        else
        {
            not_enough_star_txt.enabled = true;
            StartCoroutine(disable_not_enough_star_text());
        }
    }
    public void on_50_star_15_health_clicked()
    {
        if (get_game_item_script.star-50 >= 0)
        {
            get_game_item_script.heath = get_game_item_script.heath + 15;
            get_game_item_script.star = get_game_item_script.star - 50;
        }
        else
        {
            not_enough_star_txt.enabled = true;
            StartCoroutine(disable_not_enough_star_text());
        }
    }
    public void on_100_star_30_health_clicked()
    {
        if (get_game_item_script.star-100 >= 0)
        {
            get_game_item_script.heath = get_game_item_script.heath + 30;
            get_game_item_script.star = get_game_item_script.star - 100;
        }
        else
        {
            not_enough_star_txt.enabled = true;
            StartCoroutine(disable_not_enough_star_text());
        }
    }
    //Stopwatch
    public void on_10_star_5_stopwatch_clicked()
    {
        if (get_game_item_script.star-10 >= 0)
        {
            get_game_item_script.stopwatch = get_game_item_script.stopwatch + 5;
            get_game_item_script.star = get_game_item_script.star - 10;
        }
        else
        {
            not_enough_star_txt.enabled = true;
            StartCoroutine(disable_not_enough_star_text());
        }
    }
    public void on_50_star_25_stopwatch_clicked()
    {
        if (get_game_item_script.star-50 >= 0)
        {
            get_game_item_script.stopwatch = get_game_item_script.stopwatch + 25;
            get_game_item_script.star = get_game_item_script.star - 50;
        }
        else
        {
            not_enough_star_txt.enabled = true;
            StartCoroutine(disable_not_enough_star_text());
        }
    }
    public void on_100_star_50_stopwatch_clicked()
    {
        if (get_game_item_script.star-100 >= 0)
        {
            get_game_item_script.stopwatch = get_game_item_script.stopwatch + 50;
            get_game_item_script.star = get_game_item_script.star - 100;
        }
        else
        {
            not_enough_star_txt.enabled = true;
            StartCoroutine(disable_not_enough_star_text());
        }
    }

    IEnumerator disable_not_enough_star_text()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        not_enough_star_txt.enabled = false;
    }
}
