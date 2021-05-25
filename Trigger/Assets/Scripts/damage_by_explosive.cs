using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_by_explosive : MonoBehaviour
{
    public float amount_of_damage_done_by_explosive = 0f;
    public bool explosive_triggered;  //exploded do deduct damage

    private void Start()
    {
        explosive_triggered = false;
    }
    public void do_explosive_damage(float power)
    {
        amount_of_damage_done_by_explosive = power;
        explosive_triggered = true;
    }
    public void set_trigger_for_explosive_false()
    {
        explosive_triggered = false;
    }
}
