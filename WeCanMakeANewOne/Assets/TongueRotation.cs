using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueRotation : MonoBehaviour
{
    float timer;
    Vector3 angle = new Vector3(0, 3, 0);
    void Update()
    {
        timer = Time.deltaTime;
        while (timer < 1.0f)
        {
            transform.Rotate(angle * Time.deltaTime * 100);
        }
    }
}
