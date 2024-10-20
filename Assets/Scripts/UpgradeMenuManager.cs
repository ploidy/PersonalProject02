using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    PauseManager pauseManager;
    [SerializeField] GameObject livesButton;
    
    // Start is called before the first frame update
    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMenu()
    {
        pauseManager.PauseGame();
        menu.SetActive(true);
        livesButton.SetActive(true);
    }
    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        menu.SetActive(false);
        
    }
    

}
