using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab objek yang ingin di-spawn
    public float respawnTime = 5f; // Waktu respawn dalam detik

    private GameObject spawnedObject;
    private bool isDestroyed;

    private void Start()
    {
        SpawnObject();
    }

    private void Update()
    {
        if (isDestroyed)
        {
            respawnTime -= Time.deltaTime;

            if (respawnTime <= 0f)
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        spawnedObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        isDestroyed = false;
    }

    public void DestroyObject()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
            isDestroyed = true;
            respawnTime = 5f; // Atur ulang waktu respawn
        }
    }
}
