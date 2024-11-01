using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject player;
    public float spawnRange = 50f; 
    public float spawnTimer;
    float timer;
    
    public delegate void EnemySpawnHandler (GameObject enemy);
    public static event EnemySpawnHandler OnEnemySpawn;
    
    void Start()
    {
    
    timer = spawnTimer;
    

    }

    // Update is called once per frame
    void Update()
    {
        //sets timer for enemies to spawn. **Note** revisit to have waves of enemies instead. 
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }
    void SpawnEnemy() //spawns enemies 
    {
        
        Vector3 position = RandomPosition();
        position += player.transform.position;

        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        GameObject newEnemy = Instantiate(enemyPrefab[randomEnemy]);
        newEnemy.transform.position = position;
        OnEnemySpawn?.Invoke(newEnemy);
        
    }
    private Vector3 RandomPosition() //generate spawn position outside FOV
    {
        Vector3 position = new Vector3();

        float f = Random.value > 0.5f ? -1f : 1f;
        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnRange, spawnRange);
            position.z = spawnRange * f;
        }
        else 
        {
            position.z = Random.Range(-spawnRange, spawnRange);
            position.x = spawnRange * f;
        }
         position.y = 0;

         return position;
    }
}
