using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_main_cam : MonoBehaviour
{
    #region Singleton

    public static get_main_cam instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject get_camera;
}
