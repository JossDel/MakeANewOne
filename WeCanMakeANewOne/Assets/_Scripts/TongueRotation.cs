using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueRotation : MonoBehaviour
{
    Vector3 angle = new Vector3(0, 1, 0);

    void Update()
    {
        transform.RotateAround(new Vector3(GameObject.FindGameObjectWithTag("FrogBody").transform.position.x, 0, GameObject.FindGameObjectWithTag("FrogBody").transform.position.z), angle, Time.deltaTime * 720);
    }
}
