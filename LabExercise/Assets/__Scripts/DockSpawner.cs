using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class DockSpawner : MonoBehaviour {

    // similar to the point spawner
    // needs spawn method, spawndelay, spawn interval

    // == constants ==

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
        enemyParent = ParentUtils.FindEnemyParent();
        SpawnRepeating();
    }

    private void SpawnRepeating()
    {
        InvokeRepeating(ParentUtils.SPAWN_METHOD,
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
