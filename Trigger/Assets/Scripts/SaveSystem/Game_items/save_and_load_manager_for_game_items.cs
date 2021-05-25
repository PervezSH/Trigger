using UnityEngine;
using System.Collections;

public class save_and_load_manager_for_game_items : MonoBehaviour
{
    public int star;
    public int heath;
    public int stopwatch;

    private void Start()
    {
        load_game_item_data();
        StartCoroutine(saving());
    }
    void save_game_item_data()
    {
        save_and_load_system_for_game_items.save_system_for_game_items(this);
    }
    void load_game_item_data()
    {
        data_for_game_items data = save_and_load_system_for_game_items.load_system_for_game_items();
        if(data == null)
        {
            Debug.Log("Not saved yet");
        }
        else
        {
            star = data.star_d;
            heath = data.health_d;
            stopwatch = data.stopwatch_d;
        }
    }
    IEnumerator saving()
    {
        save_game_item_data();
        yield return new WaitForSecondsRealtime(1.0f);
        StartCoroutine(saving());
    }
}
