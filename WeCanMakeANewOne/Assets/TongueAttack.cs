using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    //TO DO set starting point relative to frog position
    public Transform left;
    public Transform right;

    //Time to move from left to right
    public float swipeTime = 1.0f;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        //Center of the arc
        Vector3 center = (left.position + right.position) * 0.5f;

        ////Move center down a bit to make arc vertical
        //center -= new Vector3(0, 1, 0);

        //Interpolate over the arc relative to center
        Vector3 leftRelCenter = left.position - center;
        Vector3 rightRelCenter = right.position - center;

        float fracComplete = (Time.time - startTime) / swipeTime;

        transform.position = Vector3.Slerp(leftRelCenter, rightRelCenter, fracComplete);
        transform.position += center;
    }
}
