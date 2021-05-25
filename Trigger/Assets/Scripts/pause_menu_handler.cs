using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class pause_menu_handler : MonoBehaviour
{
    [SerializeField] Color pressed_color;
    [SerializeField] Color normal_color;

    [Header("UI Ref")]
    [SerializeField] GameObject hud;
    [SerializeField] GameObject buttons_and_joysticks;
    [SerializeField] GameObject pause_menu;
    [SerializeField] GameObject extra_menu;

    [Header("For Resume Button")]
    [SerializeField] button_script resume_button;
    [SerializeField] TextMeshProUGUI resume_text;

    [Header("For Restart Button")]
    [SerializeField] button_script restart_button;
    [SerializeField] TextMeshProUGUI restart_text;

    [Header("For Main Menu Button")]
    [SerializeField] button_script main_menu_button;
    [SerializeField] TextMeshProUGUI main_menu_text;

    [Header("For Sound Button")]
    [SerializeField] button_script sound_button;
    [SerializeField] TextMeshProUGUI sound_text;

    [Header("For Controls Button")]
    [SerializeField] button_script control_button;
    [SerializeField] TextMeshProUGUI control_text;
    [SerializeField] GameObject control_menu;

    [Header("For Exit Button")]
    [SerializeField] button_script exit_button;
    [SerializeField] TextMeshProUGUI exit_text;

    [Header("For Extra Button")]
    [SerializeField] button_script extra_button;
    [SerializeField] TextMeshProUGUI extra_text;
    [SerializeField] extra_menu_handler get_extra_menu_script;

    //properties
    float current_time_scale = 1.0f;
    public bool adding_time;
    private void Awake()
    {
        pause_menu.SetActive(false);
        control_menu.SetActive(false);
        extra_menu.SetActive(false);
        adding_time = false;
        if(AudioListener.volume == 0.0f)
        {
            sound_text.text = "Sound Off";
        }
        else
        {
            sound_text.text = "Sound On";
        }
    }
    private void Update()
    {
        //For Resume text color tint
        if (resume_button.Pressed)
        {
            resume_text.color = pressed_color;
        }
        else
        {
            resume_text.color = normal_color;
        }
        //For Restart text color tint
        if (restart_button.Pressed)
        {
            restart_text.color = pressed_color;
        }
        else
        {
            restart_text.color = normal_color;
        }
        //For Main Menu text color tint
        if (main_menu_button.Pressed)
        {
            main_menu_text.color = pressed_color;
        }
        else
        {
            main_menu_text.color = normal_color;
        }
        //For Sound text color tint
        if (sound_button.Pressed)
        {
            sound_text.color = pressed_color;
        }
        else
        {
            sound_text.color = normal_color;
        }
        //For Sound text color tint
        if (control_button.Pressed)
        {
            control_text.color = pressed_color;
        }
        else
        {
            control_text.color = normal_color;
        }
        //For Exit text color tint
        if (exit_button.Pressed)
        {
            exit_text.color = pressed_color;
        }
        else
        {
            exit_text.color = normal_color;
        }
        //For Extra text color tint
        if (extra_button.Pressed)
        {
            extra_text.color = pressed_color;
        }
        else
        {
            extra_text.color = normal_color;
        }
    }
    public void pause_button_clicked()
    {
        if (!adding_time)
        {
            pause_menu.SetActive(true);
            hud.SetActive(false);
            buttons_and_joysticks.SetActive(false);
            current_time_scale = Time.timeScale;
            Time.timeScale = 0.0f;
        }
    }
    public void resume_button_clicked()
    {
        pause_menu.SetActive(false);
        hud.SetActive(true);
        buttons_and_joysticks.SetActive(true);
        Time.timeScale = current_time_scale;
    }
    public void restart_button_clicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public void main_menu_button_clicked()
    {
        Debug.Log("Open Main Menu");
    }
    public void sound_button_clicked()
    {
        if(sound_text.text == "Sound On")
        {
            sound_text.text = "Sound Off";
            AudioListener.volume = 0.0f;
        }
        else
        {
            sound_text.text = "Sound On";
            AudioListener.volume = 1.0f;
        }
    }
    public void exit_button_clicked()
    {
        Application.Quit();
    }
    public void extra_button_clicked()
    {
        pause_menu.SetActive(false);
        get_extra_menu_script.set_pause_menu_active_to_true();
        extra_menu.SetActive(true);
    }
    public void set_adding_time_to_false()
    {
        adding_time = false;
    }
    public void set_adding_time_to_true()
    {
        adding_time = true;
    }
    public void control_button_clicked()
    {
        control_menu.SetActive(true);
        buttons_and_joysticks.SetActive(false);
        hud.SetActive(false);
        pause_menu.SetActive(false);
    }
}
