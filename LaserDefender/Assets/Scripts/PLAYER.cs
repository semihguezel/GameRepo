using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    //configuration parameters
    [Header("Player")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float padding = 1f;
    [SerializeField] public int health = 500;
    [SerializeField] private AudioClip playerDestroySound;

    
    [Header("Projectile")]
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileFiringPeriod = 0.5f;
    [SerializeField] private AudioClip projectileSound;
    
    //States
    float _xMin;

    float _xMax;

    float _yMin;

    float _yMax;
    
    private Coroutine _firingCoroutine;
    private Enemy _enemyShip;
    private GameSession _gameSession;
    
  
    // Start is called before the first frame update
    void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        SetWorldBoundries();
    }

    // Update is called once per frame
   
    void Update()
    {
        Move();
        Fire();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -=damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Debug.Log("öldüm");
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<Level>().GG();
        AudioSource.PlayClipAtPoint(playerDestroySound, transform.position, 1f);
        Destroy(gameObject);
    }
    public int PlayerHealthCounter()
    {
        return health;
    }
    
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _firingCoroutine = StartCoroutine((FireContinuously()));
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(_firingCoroutine);
        }
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")* Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        
        var newXPose = Mathf.Clamp(transform.position.x + deltaX,_xMin,_xMax);
        var newYPose = Mathf.Clamp(transform.position.y + deltaY,_yMin,_yMax);
        
        transform.position = new Vector2(newXPose,newYPose);
        
    }
    private void SetWorldBoundries()
    {     
        Camera _gameCamera = Camera.main;
        _xMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        _xMax = _gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        _yMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        _yMax = _gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    IEnumerator FireContinuously()
    {   while(true)
        {
            GameObject laser =
                Instantiate(playerLaser, transform.position,
                    quaternion.identity) as GameObject; //just use your ration you have 
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
            AudioSource.PlayClipAtPoint(projectileSound,transform.position,1f);
        }
    }

}