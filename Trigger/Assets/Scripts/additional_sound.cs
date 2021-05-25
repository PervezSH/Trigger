using UnityEngine;

public class additional_sound : MonoBehaviour
{
    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip timer_sound;

    private void Start()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }
    public void play_respawn_timer_sound()
    {
        aud.PlayOneShot(timer_sound);
    }
}
