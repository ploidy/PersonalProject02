using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    PauseManager pauseManager;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeInHierarchy == false)
            {
            OpenMenu();
            }
            else 
            {
            CloseMenu();    
            }
        }
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        menu.SetActive(false);
        
    }
    
    public void OpenMenu()
    {
        pauseManager.PauseGame();
        menu.SetActive(true);
    }

    public void StartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
