using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    private GameObject Demon;
    [SerializeField]
    private float spawnDelay = 10;

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(Demon, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }
}
