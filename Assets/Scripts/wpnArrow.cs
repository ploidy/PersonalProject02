using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wpnArrow : MonoBehaviour
{
    public float timeToAttack;
    public GameObject arrowPrefab;
    [SerializeField]float timer;
    public Transform arrowDirection;
    public AudioClip arrowSound;
    [SerializeField] AudioSource arrowAudio;
    public GameObject player;
    [SerializeField] GameObject button;
    [SerializeField] UpgradeMenuManager upgradeMenu;
    [SerializeField] TextMeshProUGUI atkSpdText;
    
    // Start is called before the first frame update
    void Start()
    {
        arrowAudio = GetComponent<AudioSource>();
        timeToAttack = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        atkSpdText.SetText("AtkSpd: " + timeToAttack + " (MAX 1)");
       
        //sets timer for firing arrows
        if(timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnArrow();
    }
    void SpawnArrow() //spawns arrow 
    {
        Instantiate(arrowPrefab, arrowDirection.position, arrowDirection.rotation);
        arrowAudio.PlayOneShot(arrowSound, 1.0f);
    }

    public void UpgradeArrow()
    {
        if (timeToAttack <= 1.0f)
        {
            timeToAttack = 1.0f;
            button.SetActive(false);
        }
        else 
        {
        timeToAttack -= 0.2f;
        upgradeMenu.CloseMenu();
        }
    }
}
