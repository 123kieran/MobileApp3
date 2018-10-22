using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Utilities;

public class PointSpawner : MonoBehaviour {

    [SerializeField]
    private float spawnDelay = 0.5f;
    [SerializeField]
    private float spawnInterval = 1.5f;
    [SerializeField]
    //    private GameObject enemyPrefab; // type to spawn
    private Enemy enemyPrefab;

    // list for the child SpawnPoints
    private IList<SpawnPoint> spawnPoints;

    private Stack<SpawnPoint> spawnStack;

    private GameObject enemyParent;

	// Use this for initialization
	void Start () {
        enemyParent = ParentUtils.FindEnemyParent();
        // get the list of child object
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        SpawnEnemiesRepeating();
	}

    private void SpawnEnemiesRepeating()
    {
        // shuffle my stack first (from Utilities namespace)
        spawnStack = ListUtility.CreateShuffledStack(spawnPoints);
        InvokeRepeating(ParentUtils.SPAWN_METHOD, spawnDelay, spawnInterval);
    }

    private void Spawn()
    {
        // take spawn point from stack
        // if the stack is empty, then reshuffle 
        if( spawnStack.Count == 0)
        {
            // reshuffle
            spawnStack = ListUtility.CreateShuffledStack(spawnPoints);
        }

        var spawnPoint = spawnStack.Pop();

        var enemy = Instantiate(enemyPrefab, enemyParent.transform);
        // set the position
        enemy.transform.position = spawnPoint.transform.position;

    }
    // Update is called once per frame
    void Update () {
		
	}
}
