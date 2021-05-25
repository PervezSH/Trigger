using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_UI_handler : MonoBehaviour
{
    [Header("Health Bar")]
    [SerializeField] Slider Slider;
    [SerializeField] character_health get_character_health_info;
    [SerializeField] Image get_fill_image;

    [SerializeField] Color low_color;
    [SerializeField] Color full_color;

    [SerializeField] float fill_amount;

    [Header("Blood Flashing")]

    [SerializeField] Image get_blood_effect;
    [SerializeField] Color damage_color;
    [SerializeField] Color no_color;
    [SerializeField] float flashing_time;
    
    private void Update()
    {
        Slider.value = get_character_health_info.Health;

        do_change_health_bar_color();
    }
    void do_change_health_bar_color()
    {
        fill_amount = get_character_health_info.Health / 100f;
        get_fill_image.color = Color.Lerp(low_color, full_color, fill_amount);
    }
    public void do_blood_flashing(float increase_in)    //this code flashes blood when hitted by a bullet 
    {
        damage_color.a = damage_color.a + increase_in;
        get_blood_effect.color = damage_color;
        Invoke("set_color_zero", 0.1f);
    }
    void set_color_zero()
    {
        get_blood_effect.color = Color.Lerp(damage_color, no_color, flashing_time);
    }
    public void health_regenarated()    //this code remove the blood effect on the screen when get healed
    {
        get_blood_effect.color = no_color;
    }
    public void do_explosive_blood_flashing(float alpha)
    {
        damage_color.a = alpha/100;
        get_blood_effect.color = damage_color;
        Invoke("set_color_zero", 0.1f);
    }
}
