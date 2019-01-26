using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqrrrrrrrlShooting : MonoBehaviour
{
    public int damagePerShot = 100;
    public int ammo = 1;
    //public float range = 100f;

    //shot
    public GameObject acornPrefab;
    public Transform ShotSpawn;

    void Update()
    {
        if(Input.GetButton("Fire1") && ammo > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var acorn = (GameObject)Instantiate(acornPrefab, ShotSpawn.position, ShotSpawn.rotation);
        acorn.GetComponent<Rigidbody>().velocity = acorn.transform.forward * 15;
        Destroy(acorn, 2.0f);
        ammo -= 1;

    }

}
