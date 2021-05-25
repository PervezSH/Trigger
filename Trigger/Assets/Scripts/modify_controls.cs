using UnityEngine;
using UnityEngine.UI;

public class modify_controls : MonoBehaviour
{
    [SerializeField] Camera main_cam;
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch_0 = Input.GetTouch(0);
            RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(main_cam.ScreenToWorldPoint(touch_0.position).x, main_cam.ScreenToWorldPoint(touch_0.position).y), Vector2.zero, 0.0f);

            if (hit2D)
            {
                Image get_image = hit2D.transform.gameObject.GetComponent<Image>();
                Debug.Log(get_image.name);
            }
        }
    }
}
