using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class level_complete_ : MonoBehaviour
{
    [SerializeField] Timer get_the_timer_script;
    [SerializeField] GameObject level_complete_menu;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject buttons_and_joys;
    [SerializeField] AudioSource leveL_complete_aud;

    [Header("Stars")]
    [SerializeField] save_and_load_manager_for_game_items get_the_script_for_game_items;
    [SerializeField] Image star_2;
    [SerializeField] Image star_3;
    bool time_added;

    [Header("Level Complete Items UI Ref")]
    [SerializeField] TextMeshProUGUI star_no;
    [SerializeField] TextMeshProUGUI health_no;
    [SerializeField] TextMeshProUGUI stopwatch_no;
    private void Start()
    {
        leveL_complete_aud = this.gameObject.GetComponent<AudioSource>();
        time_added = false;
        level_complete_menu.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0.0f;
            hud.SetActive(false);
            buttons_and_joys.SetActive(false);
            level_complete_menu.SetActive(true);
            leveL_complete_aud.Play();
            if (!time_added)
            {
                if (get_the_timer_script.total_time >= 10)
                {
                    get_the_script_for_game_items.star = get_the_script_for_game_items.star + 3;
                }
                else if (get_the_timer_script.total_time >= 5)
                {
                    get_the_script_for_game_items.star = get_the_script_for_game_items.star + 2;
                    star_3.enabled = false;
                }
                else
                {
                    get_the_script_for_game_items.star = get_the_script_for_game_items.star + 1;
                    star_2.enabled = false;
                    star_3.enabled = false;
                }
            }
            else
            {
                get_the_script_for_game_items.star = get_the_script_for_game_items.star + 1;
                star_2.enabled = false;
                star_3.enabled = false;
            }
            star_no.text = get_the_script_for_game_items.star.ToString();
            health_no.text = get_the_script_for_game_items.heath.ToString();
            stopwatch_no.text = get_the_script_for_game_items.stopwatch.ToString();
        }
    }
    public void on_time_adding()
    {
        time_added = true;
    }
}
