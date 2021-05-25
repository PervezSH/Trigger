using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class data_for_game_items
{
    public int star_d;
    public int health_d;
    public int stopwatch_d;

    public data_for_game_items(save_and_load_manager_for_game_items game_Items)
    {
        star_d = game_Items.star;
        health_d = game_Items.heath;
        stopwatch_d = game_Items.stopwatch;
    }

}
