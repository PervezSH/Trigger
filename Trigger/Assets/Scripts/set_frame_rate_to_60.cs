using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_frame_rate_to_60 : MonoBehaviour
{
    
    void Update()
    {
        
        Application.targetFrameRate = 60;
    }
}
