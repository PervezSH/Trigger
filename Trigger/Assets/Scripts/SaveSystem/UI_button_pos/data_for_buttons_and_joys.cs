using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class data_for_buttons_and_joys
{
    public float[] joys_trans_data;
    public float[] fire_trans_data;
    public float[] jump_trans_data;
    public float[] reload_trans_data;
    public float[] slow_mo_trans_data;

    public data_for_buttons_and_joys(RectTransform get_j_t,RectTransform get_f_t,RectTransform get_jp_t,RectTransform get_r_t,RectTransform get_s_t)
    {
        joys_trans_data = new float[3];
        joys_trans_data[0] = get_j_t.localPosition.x;
        joys_trans_data[1] = get_j_t.localPosition.y;
        joys_trans_data[2] = get_j_t.localPosition.z;

        fire_trans_data = new float[3];
        fire_trans_data[0] = get_f_t.localPosition.x;
        fire_trans_data[1] = get_f_t.localPosition.y;
        fire_trans_data[2] = get_f_t.localPosition.z;

        jump_trans_data = new float[3];
        jump_trans_data[0] = get_jp_t.localPosition.x;
        jump_trans_data[1] = get_jp_t.localPosition.y;
        jump_trans_data[2] = get_jp_t.localPosition.z;

        reload_trans_data = new float[3];
        reload_trans_data[0] = get_r_t.localPosition.x;
        reload_trans_data[1] = get_r_t.localPosition.y;
        reload_trans_data[2] = get_r_t.localPosition.z;

        slow_mo_trans_data = new float[3];
        slow_mo_trans_data[0] = get_s_t.localPosition.x;
        slow_mo_trans_data[1] = get_s_t.localPosition.y;
        slow_mo_trans_data[2] = get_s_t.localPosition.z;
    }
}
