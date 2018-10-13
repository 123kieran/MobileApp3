using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int scoreValue = 10;

    // create public property
    public int ScoreValue { get { return scoreValue; } }

    // EnemyKilledEvent handlers
    public delegate void EnemyKilled(Enemy enemy);

    // static event
    public static EnemyKilled EnemyKilledEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // need to determin the type of "collision"
        var player = collision.GetComponent<PlayerBehaviour>();
        if( player)
        {
            // publish event to the system to notify of hit.
            PublishEnemyKilledEvent();
            // destory the current gameObject
            Destroy(gameObject);

        }
        else
        {
            Debug.Log("hit something else");
        }
    }

    private void PublishEnemyKilledEvent()
    {
        if( EnemyKilledEvent != null)
        {
            EnemyKilledEvent(this);
        }

    }
}
