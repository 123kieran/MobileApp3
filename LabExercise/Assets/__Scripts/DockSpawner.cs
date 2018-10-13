using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockSpawner : MonoBehaviour {

    // similar to the point spawner
    // needs spawn method, spawndelay, spawn interval

    // == constants ==
    private const string SPAWN_METHOD = "Spawn";
    private const string ENEMY_PARENT_NAME = "Enemies";

    // == fields ==
    [SerializeField]
    private float spawnDelay = 0.4f;
    [SerializeField]
    private float spawnInterval = 1.3f;
    [SerializeField]
    private float enemyStartSpeed = 2f;
    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    [Header("Transform Array")]
    private Transform[] waypoints;  // add to triangles

    private GameObject enemyParent;

    // == private methods ==
    private void Start()
    {
        enemyParent = GameObject.Find(ENEMY_PARENT_NAME);
        if(!enemyParent)
        {
            enemyParent = new GameObject(ENEMY_PARENT_NAME);
        }
        SpawnRepeating();
    }

    private void SpawnRepeating()
    {
        InvokeRepeating(SPAWN_METHOD,
                        spawnDelay,
                        spawnInterval);
    }

    private void Spawn()
    {
        var enemy = Instantiate(enemyPrefab, 
                                enemyParent.transform);
        enemy.transform.position = transform.position;

        var follower = enemy.GetComponent<WaypointFollower>();
        follower.Speed = enemyStartSpeed;
        // create the path to follow
        // follower.AddPointToPath()
        foreach (var transform in waypoints)
        {
            follower.AddPointToPath(transform.position);
        }
    }


}
