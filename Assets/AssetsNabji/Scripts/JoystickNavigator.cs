using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class JoystickNavigator : MonoBehaviour
{
    [Header("Animators")]

    /// set this to false to prevent input to be detected
    [Tooltip("set the animators of every menu here")]
    public Animator animator_new_game;
    public Animator animator_load_game;
    public Animator animator_options;
    public Animator animator_unlocked;
    public Animator animator_credits;


    [Header("First button Selected")]

    /// set this to false to prevent input to be detected
    [Tooltip("set here the first button in every menu")]

    public GameObject GO_principal;
    public GameObject GO_new_game;
    public GameObject GO_load_game;
    public GameObject GO_options;
    public GameObject GO_unlocked;
    public GameObject GO_credits;


    private Dictionary<GameObject, Animator> _menus;
    private GameObject _currentMenu;

    // Start is called before the first frame update
    void Start()
    {
        _menus = new Dictionary<GameObject, Animator>
        {
            { GO_principal, null },
            { GO_new_game, animator_new_game },
            { GO_load_game, animator_load_game },
            { GO_options, animator_options },
            { GO_unlocked, animator_unlocked },
            { GO_credits, animator_credits },
        };
        _currentMenu = GO_principal;
    }

    public void ShowMenu(GameObject menuToShow)
    {
        _menus[_currentMenu].SetBool("isHidden", true);
        _menus[menuToShow].SetBool("isHidden", false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menuToShow);
        _currentMenu = menuToShow;
    }

    public void HideMenu()
    {
        _menus[_currentMenu].SetBool("isHidden", true);
        _menus[GO_principal].SetBool("isHidden", false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_principal);
        _currentMenu = GO_principal;
    }
}