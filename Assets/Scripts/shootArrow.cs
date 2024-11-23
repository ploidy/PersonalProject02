using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrow : MonoBehaviour
{
    public float speed;
    public float Lifespan;
    public GameObject arrow;
    //private Transform target;
    //private bool homing;
    
    
    
    private Rigidbody arrowRB;
    //public AudioClip arrowSound;
    //private AudioSource arrowAudio;
    // Start is called before the first frame update



    
    private void Awake()
    {
        arrowRB = GetComponent<Rigidbody>();
        arrowRB.isKinematic = false;
        arrowRB.collisionDetectionMode = CollisionDetectionMode.Continuous;
        
    }
    
    //private void OnEnable(){DetectCollisions.OnArrowHit += DestroyArrow;}

    //private void OnDisable()
    //{
    //DetectCollisions.OnArrowHit -= DestroyArrow;
    //}

    
    void Start()
    {
        //arrowRB = GetComponent<Rigidbody>();
        //arrowAudio = GetComponent<AudioSource>();
        
    }
    


    // Update is called once per frame
    void Update()
    {
        //fire arrow in 'forward' direction and destroy after Lifespan seconds **NOTE: consider firing at nearest enemey instead
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Destroy(gameObject, Lifespan);
        }

    //void DestroyArrow (GameObject arrow)
    //{
        //if (arrow == gameObject)
        //{
            //Destroy(gameObject);
        //}
    //}
}
