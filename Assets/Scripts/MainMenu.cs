using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public delegate void MenuHandler();
    public static event MenuHandler OnMenuOpen;
    public static event MenuHandler OnMenuClose;

    
    // Start is called before the first frame update
    void Start()
    {
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
        menu.SetActive(false);
        OnMenuClose?.Invoke();
        
    }
    
    public void OpenMenu()
    {
        menu.SetActive(true);
        OnMenuOpen?.Invoke();
    }

    public void StartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
