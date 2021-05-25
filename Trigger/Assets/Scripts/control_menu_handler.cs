using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class control_menu_handler : MonoBehaviour
{
    [SerializeField] Color pressed_color;
    [SerializeField] Color normal_color;

    [Header("UI Ref")]
    [SerializeField] GameObject hud;
    [SerializeField] GameObject buttons_and_joysticks;
    [SerializeField] GameObject pause_menu;
    [SerializeField] GameObject control_menu;

    [Header("For Exit Button")]
    [SerializeField] button_script exit_button;
    [SerializeField] TextMeshProUGUI exit_button_text;

    [Header("For Save Button")]
    [SerializeField] button_script save_button;
    [SerializeField] TextMeshProUGUI save_button_text;

    [Header("Original Buttons and Joystick")]
    [SerializeField] GameObject joystick_org;
    [SerializeField] GameObject fire_button_org;
    [SerializeField] GameObject jump_button_org;
    [SerializeField] GameObject reload_button_org;
    [SerializeField] GameObject slow_mo_button_org;

    [Header("Dummy Buttons and Joystick")]
    [SerializeField] GameObject joystick_dum;
    [SerializeField] GameObject fire_button_dum;
    [SerializeField] GameObject jump_button_dum;
    [SerializeField] GameObject reload_button_dum;
    [SerializeField] GameObject slow_mo_button_dum;

    RectTransform j_o;
    RectTransform f_o;
    RectTransform jump_o;
    RectTransform r_o;
    RectTransform s_o;
    
    RectTransform j_d;
    RectTransform f_d;
    RectTransform jump_d;
    RectTransform r_d;
    RectTransform s_d;

    private void Start()
    {
        j_o = joystick_org.GetComponent<RectTransform>();
        f_o = fire_button_org.GetComponent<RectTransform>();
        jump_o = jump_button_org.GetComponent<RectTransform>();
        r_o = reload_button_org.GetComponent<RectTransform>();
        s_o = slow_mo_button_org.GetComponent<RectTransform>();

        j_d = joystick_dum.GetComponent<RectTransform>();
        f_d = fire_button_dum.GetComponent<RectTransform>();
        jump_d = jump_button_dum.GetComponent<RectTransform>();
        r_d = reload_button_dum.GetComponent<RectTransform>();
        s_d = slow_mo_button_dum.GetComponent<RectTransform>();

    }
    private void Update()
    {
        //For Exit text color tint
        if (exit_button.Pressed)
        {
            exit_button_text.color = pressed_color;
        }
        else
        {
            exit_button_text.color = normal_color;
        }
        //For Save text color tint
        if (save_button.Pressed)
        {
            save_button_text.color = pressed_color;
        }
        else
        {
            save_button_text.color = normal_color;
        }
    } 
    public void control_menu_exit_button_clicked()
    {
        control_menu.SetActive(false);
        buttons_and_joysticks.SetActive(false);
        hud.SetActive(false);
        pause_menu.SetActive(true);
    }
    public void control_menu_save_button_clicked()
    {
        j_o.transform.localPosition = j_d.transform.localPosition;
        f_o.transform.localPosition = f_d.transform.localPosition;
        jump_o.transform.localPosition = jump_d.transform.localPosition;
        r_o.transform.localPosition = r_d.transform.localPosition;
        s_o.transform.localPosition = s_d.transform.localPosition;
    }
}
