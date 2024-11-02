using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject enemy;
    public float mapRange = 245f;
    public float rotationSpeed = 60.0f;
    public int enemyXp;
    public int enemyHp;
    public int currentHp;
    public int damage;
    public ParticleSystem deathParticle;
    public GameObject smokeObject;
    [SerializeField] GameObject smokeObjectTemp;
    public float smokeTime = 0.5f;

    public static event Action<int> OnEnemyDead;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        damage = 1;
        currentHp = enemyHp;
    }

private void OnEnable()
{
        EnemyCollisions.OnArrowHit += TakeArrowDamage;
        EnemyCollisions.OnSpcAtkHit += TakeSpcDamage;
        EnemyCollisions.OnEnemyHit += SlowOnHit;
}

    // Update is called once per frame
    void Update()
    {
        //Enemies find player direction and move towards player ** Note - fix enemies overshooting player location
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        transform.position += lookDirection * speed * Time.deltaTime;

       // stops Enemies moving out of bounds
       if (transform.position.x < -mapRange)
       {
        transform.position = new Vector3(-mapRange, transform.position.y, transform.position.z);
       }
       if (transform.position.x > mapRange)
       {
        transform.position = new Vector3(mapRange, transform.position.y, transform.position.z);
       }
       if (transform.position.z < -mapRange)
       {
        transform.position = new Vector3(transform.position.x, transform.position.y, -mapRange);
       }
       if (transform.position.z > mapRange)
       {
        transform.position = new Vector3(transform.position.x, transform.position.y, mapRange);
       }

        if(currentHp <= 0)
        {
        EnemyDead();
        }
    
    }
    void SlowOnHit(GameObject enemy)
    {
        if (enemy == gameObject)
        {
        currentHp -= damage;
        deathParticle.Play();
        Debug.Log("Enemy Slowed!");
        StartCoroutine(SlowSpeed());
        }
    }
    
    IEnumerator SlowSpeed()
    {
            speed = speed * 0.4f;
            yield return new WaitForSeconds (2.0f);
            speed = speed * 2.5f;
    }
    
    void TakeArrowDamage(GameObject enemy)
    {
        if (enemy == gameObject)
            {
            Debug.Log("Enemy Hit!");
            currentHp -= damage;
            deathParticle.Play();
            }
    }
    
    void TakeSpcDamage(GameObject enemy)
    {
        if (enemy == gameObject)
        {
        Debug.Log("Enemy Hit by Special!");
        currentHp -= damage * 2;
        deathParticle.Play();
        }
    }
    
    void EnemyDead()
    {
        Debug.Log("Enemy has died");
        OnEnemyDead?.Invoke(enemyXp);
        Destroy(gameObject);
        smokeObjectTemp = Instantiate(smokeObject);
        Instantiate(smokeObjectTemp, transform.position,transform.rotation);
        Destroy(smokeObjectTemp, smokeTime);
      }
    
    void OnDisable()
    {
        EnemyCollisions.OnArrowHit -= TakeArrowDamage;
        EnemyCollisions.OnSpcAtkHit -= TakeSpcDamage;
        EnemyCollisions.OnEnemyHit -= SlowOnHit;
    }
}
