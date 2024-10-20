using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float mapRange = 245f;
    //public Transform target;
    public float rotationSpeed = 60.0f;
    
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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


    
    }
    IEnumerator OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Player")) //slows enemy after contact with player
        {
        speed = speed * 0.4f;
        yield return new WaitForSeconds (2.0f);
        speed = speed * 2.5f;

        }
    }
}
