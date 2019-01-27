using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        //var health = hit.GetComponent<EnemyHealth>();
        //if (health != null)
        //{
        //    health.TakeDamage(1);
        //}
        Destroy(gameObject);
    }
}
