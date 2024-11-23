using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFollowPlayer : MonoBehaviour
{
 public GameObject player;
    

    void FixedUpdate() 
    {
        {
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 50, player.transform.position.z);
        }
    }
}
