﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy")]
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBtwShots = 0.2f;
    [SerializeField] float maxTimeBtwShots = 3f;
    [SerializeField] int enemyScore = 50;

    [Header("Projectiles")]
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip laserSound;
    [SerializeField] float volume;
    


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownAndShoot();
    }

    private void CountdownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
        }
    }


    private void Fire()
    {
        GameObject enemyLasers = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        enemyLasers.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
        AudioSource.PlayClipAtPoint(laserSound, transform.position, volume);
        Destroy(laserSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(enemyScore);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, 1f);
        AudioSource.PlayClipAtPoint(deathSound, transform.position, volume);
    }
}
