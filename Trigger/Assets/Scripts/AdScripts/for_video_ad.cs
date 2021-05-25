using UnityEngine;
using UnityEngine.Advertisements;

public class for_video_ad : MonoBehaviour , IUnityAdsListener   
{
    string gameId = "3563267";
    string myPlacementId = "rewardedVideo";
    bool testMode = true;
    [SerializeField] GameObject go_of_ad_not_loaded;

    [Header("For Health And Stopwatch")]
    [SerializeField] buy_watch_ad_menu_handler get_the_reward_giving_script;

    [Header("For Time Out")]
    [SerializeField] Timer get_the_script_for_adding_time;
    bool add_timeout_clicked;

    [Header("For Death")]
    [SerializeField] death_menu_handler get_the_script_for_respawning;
    bool respawn_clicked;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        go_of_ad_not_loaded.SetActive(false);
        add_timeout_clicked = false;
        respawn_clicked = false;
    }

    public void on_watch_ad_clicked()
    {
        Advertisement.Show(myPlacementId);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            if (add_timeout_clicked)
            {
                get_the_script_for_adding_time.add_time_ad_watched();
                add_timeout_clicked = false;
            }
            else if (respawn_clicked)
            {
                get_the_script_for_respawning.respawn_ad_watched();
                respawn_clicked = false;
            }
            else
            {
                get_the_reward_giving_script.give_the_rewards_ad_watched();
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
        }
        else if (showResult == ShowResult.Failed)
        {
            
        }
    }
    //For Time Adding
    public void set_add_time_clicked_to_true()
    {
        add_timeout_clicked = true;
    }
    public void set_respawn_clicked_to_true()
    {
        respawn_clicked = true;
    }


    public void OnUnityAdsReady(string placementId)
    {
    }
    public void OnUnityAdsDidError(string message)
    {
    }
    public void OnUnityAdsDidStart(string placementId)
    {
    }
}
