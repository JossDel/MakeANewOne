using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqrrrrrrrlShooting : MonoBehaviour
{
    public int damagePerShot = 100;
    public float timer;

    //shot
    public GameObject acornPrefab;
    public Transform ShotSpawn;

    void Update()
    {
        timer = Time.deltaTime;
        if(Input.GetButton("Fire1") && timer > 2.0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var acorn = (GameObject)Instantiate(acornPrefab, ShotSpawn.position, ShotSpawn.rotation);
        acorn.GetComponent<Rigidbody>().velocity = acorn.transform.forward * 15;
        Destroy(acorn, 2.0f);
        timer = 0;

    }

}
