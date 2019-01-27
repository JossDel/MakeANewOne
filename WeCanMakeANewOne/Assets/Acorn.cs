using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        //var health = hit.GetComponent<EnemyHealth>();
        //if (health != null)
        //{
        //    health.TakeDamage(1);
        //}
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
