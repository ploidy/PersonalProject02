using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject player;

    public delegate void CollisionEventHandler ();
    public static event CollisionEventHandler OnPlayerHit; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) 
    { 
        if (collision.gameObject.tag == "Enemy")
        {
            OnPlayerHit?.Invoke();
        }
    }
}
