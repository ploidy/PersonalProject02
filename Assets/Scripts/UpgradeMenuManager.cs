using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    PauseManager pauseManager;
    [SerializeField] GameObject livesButton;

    public delegate void MenuHandler();
    public static event MenuHandler OnMenuOpen;
    public static event MenuHandler OnMenuClose;
    
    // Start is called before the first frame update
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMenu()
    {
        menu.SetActive(true);
        livesButton.SetActive(true);
        OnMenuOpen?.Invoke();
    }
    public void CloseMenu()
    {
        menu.SetActive(false);
        OnMenuClose?.Invoke();
    }
    
    void OnEnable()
    {
        Level.OnLevelup += OpenMenu;
    }

    void OnDisable ()
    {
        Level.OnLevelup -= OpenMenu;
    }
}
