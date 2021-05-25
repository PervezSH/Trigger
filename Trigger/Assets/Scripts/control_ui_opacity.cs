using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_ui_opacity : MonoBehaviour
{
    Image get_the_swap_image;
    [SerializeField] Color no_alpha;
    [SerializeField] Color alpha;

    [SerializeField] Camera get_main_cam;
    private void Awake()
    {
        get_the_swap_image = this.gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(get_main_cam.transform.position,get_main_cam.transform.forward,out hit, 5f))
        {
            if(hit.collider.name == "AKM_scattered" || hit.collider.name == "AKM_scattered(Clone)" || hit.collider.name == "M1911_scattered" || hit.collider.name == "M1911_scattered(Clone)" || hit.collider.name == "Remington 870_scattered" || hit.collider.name == "Remington 870_scattered(Clone)")
            {
                change_ui_opacity();
            }
            else
            {
                change_ui_opacity_to_zero();
            }
        }
    }
    void change_ui_opacity()
    {
        get_the_swap_image.color = alpha;
    }
    void change_ui_opacity_to_zero()
    {
        get_the_swap_image.color = no_alpha;
    }
}
