using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // == fields ==
    private int playerScore = 0;


    // subscribe to events here
    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += HandleEnemyKilledEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= HandleEnemyKilledEvent;
    }

    private void HandleEnemyKilledEvent(Enemy enemy)
    {
        playerScore += enemy.ScoreValue;
        Debug.Log("Score: " + playerScore);
    }
}
