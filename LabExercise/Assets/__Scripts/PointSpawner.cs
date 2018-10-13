using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PointSpawner : MonoBehaviour {
    // random allocation of spawn points.
    // create list of spawn points
    // randomly select one
    // instantiante enemy object
    // set the transform.positions equal
    [SerializeField]
    private float spawnDelay = 0.2f;
    [SerializeField]
    private float spawnInterval = 1.5f;

    [SerializeField]
    private GameObject enemyPrefab;

    private const string SPAWN_METHOD = "Spawn";
    private IList<SpawnPoint> spawnPoints;

	// Use this for initialization
	void Start () {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
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
        // generate the enemy ship here.
        // get a random index to the list
        var randomIndex = Random.Range(0, spawnPoints.Count);
        var spawnHere = spawnPoints[randomIndex];

        // instantiate an enemy ship
        var enemy = Instantiate(enemyPrefab);
        // set the position
        enemy.transform.position = spawnHere.transform.position;

    }
    // Update is called once per frame
    void Update () {
		
	}
}
