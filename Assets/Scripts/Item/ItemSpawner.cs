using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;

    public Transform playerTransform;

    public float maxDistance = 20.0f;

    public float timestepSpawnMax = 10.0f;
    public float timestepSpawnMin = 5.0f;

    private float timestepSpawn;
    private float lastSpawnTime;

    private void Start()
    {
        timestepSpawn = Random.Range(timestepSpawnMin, timestepSpawnMax);
        lastSpawnTime = 0;
    }

    private void Update()
    {
        if (Time.time >= lastSpawnTime + timestepSpawn && playerTransform != null)
        {
            lastSpawnTime = Time.time;
            timestepSpawn = Random.Range(timestepSpawnMin, timestepSpawnMax);
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = GetRandomPointOnNavMesh(playerTransform.position, maxDistance);
        spawnPosition += Vector3.up * 0.5f;

        GameObject item = Instantiate(items[Random.Range(0, items.Length)], spawnPosition, Quaternion.identity);

        Destroy(item, 10.0f);
    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance)
    {
        Vector3 randomPosition = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomPosition, out hit, distance, NavMesh.AllAreas);

        return hit.position;
    }
}