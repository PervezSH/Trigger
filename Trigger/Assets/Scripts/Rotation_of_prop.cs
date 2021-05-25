using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_of_prop : MonoBehaviour
{
    float rotation_speed = 50f;
    void Update()
    {
        transform.Rotate(Vector3.forward * rotation_speed * Time.deltaTime);
    }
}
