using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_player_health_script : MonoBehaviour
{
    #region Singleton

    public static get_player_health_script instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject get_player;
}
