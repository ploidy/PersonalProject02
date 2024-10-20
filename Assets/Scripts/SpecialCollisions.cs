using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCollisions : MonoBehaviour
{
    [SerializeField] float lifespan; //test
    
    void Start()
    {
        lifespan = 3.0f;
    }

    
    void Update()
    {
        Destroy (gameObject,lifespan);
    }


 
}
