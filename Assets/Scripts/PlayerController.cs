using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;


public class PlayerController : MonoBehaviour
{
    
    public float speed = 20.0f;
    public Vector3 forward;
    Vector3 right;
    public float mapRange = 245;
    [SerializeField] AudioSource playerAudio;
    public AudioClip hitSound;
    //private Rigidbody playerRb;
    public float obstacleBounce = 5.0f;
    public int currentLives;
    public int maxHp = 3;
    [SerializeField] int damage = 1;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI cDwnText;
    //private Animator playerAnim;
    public float specialAtkCooldown;
    [SerializeField] private float cooldownValue;
    public GameObject specialAtkPrefab;
    public Transform specialAtkDirection;
    [SerializeField] GameObject livesButton;
    [SerializeField] GameObject specialButton;
    [SerializeField] UpgradeMenuManager upgradeMenu;
    public GameObject specialIndicator;
    public bool hasSpecial;
    //public Animator anim;

    public static event Action OnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        //playerAnim = GetComponent<Animator>();
        
        //sets 'forward' & right to camera view
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;

        currentLives = maxHp;
        specialAtkCooldown = 0;
        cooldownValue = 10;
        hasSpecial = true;
        
        PlayerCollisions.OnPlayerHit += TakeDamage;
    }


    // Update is called once per frame

    void Update()
    {
       livesText.SetText("Lives: " + currentLives);
       
       cDwnText.SetText("CoolDwn: " + cooldownValue + " (MAX 5)");
       

       if (Input.anyKey) //any input invokes Move method
            {
            Move();
            }
       
       //prevents player from going out of bounds
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
       if (Input.GetKeyDown(KeyCode.Space) && specialAtkCooldown <=0)
       {
        SpecialAtk();
       }
       if (specialAtkCooldown >0)
       {
        hasSpecial = false;
        specialIndicator.gameObject.SetActive(false);
        specialAtkCooldown -= Time.deltaTime;
       }
       if (specialAtkCooldown <=0)
       {
        hasSpecial = true;
        specialIndicator.gameObject.SetActive(true);
        specialIndicator.transform.position = transform.position + new Vector3 (0,9.5f,0);
       }  
    }
    
    void Move() //moves player on isometric plane
    {
        new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 heading = Vector3.Normalize(upMovement + rightMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;    
    }
    
    void SpecialAtk()
    {
        Instantiate(specialAtkPrefab, specialAtkDirection.position, specialAtkDirection.rotation);

        specialAtkCooldown = cooldownValue;
    }
    
    //private void OnCollisionEnter(Collision collision) //play sound if player hit by enemy
    //{
        //if(collision.gameObject.CompareTag("Enemy"))
        //{
            //Debug.Log("Player Hit!");
            //playerAudio.PlayOneShot(hitSound, 0.2f);
            //currentLives -= damage;
                       
        //}
  
    void TakeDamage()
    {
        Debug.Log("Player Hit!");
        playerAudio.PlayOneShot(hitSound, 0.2f);
        currentLives -= damage;
        
        if(currentLives <= 0)
            {
                 currentLives = 0;
                 Debug.Log("You have died");
                 OnGameOver?.Invoke();
                 //Destroy(gameObject);
            }
    }
    
    void OnDestroy()
    {
        PlayerCollisions.OnPlayerHit -= TakeDamage;
    }
   
   
    public void ReplenishLives()
    {
    if (currentLives >= 3)
        {
        livesButton.SetActive(false);
        }
    if (currentLives < 3)
        {
        currentLives += 1;
        upgradeMenu.CloseMenu();
        }
    }
    public void UpgradeSpecialAtk()
    {
        if (cooldownValue <= 5.0f)
        {
        cooldownValue = 5.0f;
        specialButton.SetActive(false);
        }
        else 
        {
        cooldownValue -=  1.0f;
        upgradeMenu.CloseMenu();
        }
    }
}

