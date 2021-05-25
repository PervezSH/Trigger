using UnityEngine;
using UnityEngine.Advertisements;

public class for_interstitial_ad : MonoBehaviour , IUnityAdsListener
{
    string gameId = "3563267";
    bool testMode = true;
    string myPlacementId = "video";

    [SerializeField] pause_menu_handler get_the_pause_menu_script;
    bool restart_clicked;

    private void Start()
    {
        restart_clicked = false;
        Advertisement.Initialize(gameId, testMode);
    }
    public void show_interstitial_ad()
    {
        Advertisement.AddListener(this);
        Advertisement.Show(myPlacementId);
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            to_do_after_ad();
        }
        else if (showResult == ShowResult.Skipped)
        {
            to_do_after_ad();
        }
        else if (showResult == ShowResult.Failed)
        {
            to_do_after_ad();
        }
    }
    void to_do_after_ad()
    {
        if (restart_clicked)
        {
            restart_clicked = false;
            get_the_pause_menu_script.restart_button_clicked();
        }
        else
        {
            Debug.Log("Load Next Level");
        }
    }
    public void restart_clicked_on_level_complete_to_true()
    {
        restart_clicked = true;
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
