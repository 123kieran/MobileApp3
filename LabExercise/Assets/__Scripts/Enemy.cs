using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private const string TRIANGLE_TAG_TEXT = "Triangle";

    [SerializeField]
    private int scoreValue = 10;

    [SerializeField]
    private AudioClip spawnClip;

    [SerializeField]
    private AudioClip hitClip;

    [SerializeField]
    private AudioClip crashClip;

    private SoundController soundController;


    // create public property
    public int ScoreValue { get { return scoreValue; } }

    // EnemyKilledEvent handlers
    public delegate void EnemyKilled(Enemy enemy);

    // static event
    public static EnemyKilled EnemyKilledEvent;

    // == private methods ==
    private void Start()
    {
        soundController = SoundController.FindSoundController();
        PlayClip(spawnClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tagType = gameObject.tag;
        var player = collision.GetComponent<PlayerBehaviour>();
        var bullet = collision.GetComponent<Bullet>();

        if(bullet && (tagType == TRIANGLE_TAG_TEXT))
        {
            PlayClip(hitClip);
            Destroy(bullet.gameObject);
            PublishEnemyKilledEvent();
            Destroy(gameObject);
        }
        else if ( player)
        {
            PlayClip(crashClip);
            PublishEnemyKilledEvent();
            Destroy(gameObject);
        }
    }

    private void PlayClip(AudioClip clip)
    {
        if (soundController)
        {
            soundController.PlayOneShot(clip);
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
