using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_and_load_manager_for_buttons_and_joys : MonoBehaviour
{
    public RectTransform joys_and_button_trans;
    public RectTransform fire_button_trans;
    public RectTransform jump_button_trans;
    public RectTransform reload_button_trans;
    public RectTransform slow_mo_button_trans;

    [SerializeField] control_menu_handler get_the_control_menu_script;
    private void Start()
    {
        load_button_pos();
        Invoke("apply_the_button_pos", 0.01f);
    }
    public void control_save_button_clicked()
    {
        save_and_load_system_for_buttons_and_joys.save_system_for_buttons_and_joys(joys_and_button_trans, fire_button_trans, jump_button_trans, reload_button_trans, slow_mo_button_trans);

    }
    public void load_button_pos()
    {
        data_for_buttons_and_joys data = save_and_load_system_for_buttons_and_joys.load_system_for_buttons_and_joys();
        if(data == null)
        {
            Debug.Log("Do nothing");
        }
        else
        {
            Vector3 joys;
            joys.x = data.joys_trans_data[0];
            joys.y = data.joys_trans_data[1];
            joys.z = data.joys_trans_data[2];
            joys_and_button_trans.localPosition = joys;

            Vector3 fire;
            fire.x = data.fire_trans_data[0];
            fire.y = data.fire_trans_data[1];
            fire.z = data.fire_trans_data[2];
            fire_button_trans.localPosition = fire;

            Vector3 jump;
            jump.x = data.jump_trans_data[0];
            jump.y = data.jump_trans_data[1];
            jump.z = data.jump_trans_data[2];
            jump_button_trans.localPosition = jump;

            Vector3 reload;
            reload.x = data.reload_trans_data[0];
            reload.y = data.reload_trans_data[1];
            reload.z = data.reload_trans_data[2];
            reload_button_trans.localPosition = reload;

            Vector3 slow;
            slow.x = data.slow_mo_trans_data[0];
            slow.y = data.slow_mo_trans_data[1];
            slow.z = data.slow_mo_trans_data[2];
            slow_mo_button_trans.localPosition = slow;
        }
    }
    void apply_the_button_pos()
    {
        get_the_control_menu_script.control_menu_save_button_clicked();
    }
}
