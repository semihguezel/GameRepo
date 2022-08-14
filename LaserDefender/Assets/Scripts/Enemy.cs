using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.ExceptionServices;
using Unity.Profiling;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //config params
    [Header("Enemy")]
    [SerializeField] private float health = 200;
    [SerializeField] private int scoreValue = 50;
     private float shotCounter;
    [SerializeField] private float durationVFX = 1f;
    [SerializeField] private AudioClip enemyDestroySound;
    [SerializeField] private GameObject explosionEffect;
    
    [Header("Projectile")]
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private AudioClip laserSound;
    
    //cached components
    private GameSession _enemyGameSession;

    // Start is called before the first frame update
    void Start()
    {
        _enemyGameSession = FindObjectOfType<GameSession>();
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
 
    // Start is called before the first frame update

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            AudioSource.PlayClipAtPoint(laserSound,transform.position,1f);
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return; //protecting us against null reference
        }
        ProcessHit(damageDealer);
        
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _enemyGameSession.AddScore(scoreValue);
        Destroy(gameObject);
        GameObject explosionVFX =
            Instantiate(explosionEffect, transform.position,
                Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyDestroySound,transform.position,1f);
        Destroy(explosionVFX,durationVFX);
    }

    private void Fire()
    {
        GameObject laser =
            Instantiate(enemyLaser, transform.position,
                Quaternion.identity); //just use your ration you have 
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

    }
}
