using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.transform.position.x -55, player.transform.position.y + 45, player.transform.position.z -55);
    }
}
    
