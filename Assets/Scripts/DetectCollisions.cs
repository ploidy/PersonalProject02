using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //private GameManager gameManager;
    public GameObject player;
    public GameObject enemy;
    public int enemyXp;
    public int maxHp;
    public int damage;
    public ParticleSystem deathParticle;
    public GameObject smokeObject;
    [SerializeField] GameObject smokeObjectTemp;
    public float smokeTime = 0.5f;

    
    // Start is called before the first frame update

    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        damage = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(maxHp <= 0) //enemy destroyed + particle effect
        {
        Destroy(gameObject);
        smokeObjectTemp = Instantiate(smokeObject);
        Instantiate(smokeObjectTemp, transform.position,transform.rotation);
        Destroy(smokeObjectTemp, smokeTime);
        player.GetComponent<Level>().AddXp(enemyXp);
        }
    }
    void OnTriggerEnter(Collider other) { //enemy takes damage
        
        if (other.gameObject.tag == "Arrow")
        {
        maxHp -= damage;
        deathParticle.Play();
        Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SpecialAtk")
        {
        maxHp -= damage * 2;
        deathParticle.Play();
        }
        if (other.gameObject.tag == "Player")
        {
        maxHp -= damage;
        }
    }
}
