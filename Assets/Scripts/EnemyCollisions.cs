using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{

    public GameObject enemy;
    
    public delegate void CollisionEventHandler (GameObject enemy);
    public static event CollisionEventHandler OnEnemyHit;
    public static event CollisionEventHandler OnArrowHit;
    public static event CollisionEventHandler OnSpcAtkHit;

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            OnArrowHit?.Invoke(gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("SpecialAtk"))
        {
            OnSpcAtkHit?.Invoke(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            OnEnemyHit?.Invoke(gameObject);
      
        }
    }
}
