using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    public GameObject tempTongue;
    public Transform TongueSpawn;

    void Lick()
    {
        var tongue = (GameObject)Instantiate(tempTongue, TongueSpawn.position, TongueSpawn.rotation);
        Destroy(tongue, 0.25f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Lick();
        }       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            Destroy(collision.gameObject);
        }
    }

}
