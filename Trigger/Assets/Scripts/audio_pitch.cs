using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_pitch : MonoBehaviour
{
    AudioSource aud;
    private void Awake()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        aud.pitch = Time.timeScale;
    }
}
