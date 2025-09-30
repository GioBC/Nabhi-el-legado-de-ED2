/*using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavigationUI : MonoBehaviour
{
    private GameObject PauseSplash;
    public Button ResumeButton;
    public Button[] MenuButtons;
    private int currentButtonIndex = 0;

    void Start()
    {
        ResumeButton.Select();
        PauseSplash = this.gameObject;
    }

    void Update()
    {
        if (PauseSplash.activeInHierarchy)
        {
            float joystickVertical = Input.GetAxis("Player1_Vertical");

            if (joystickVertical > 0)
            {
                currentButtonIndex--;
                if (currentButtonIndex < 0)
                {
                    currentButtonIndex = MenuButtons.Length - 1;
                }
                EventSystem.current.SetSelectedGameObject(MenuButtons[currentButtonIndex].gameObject);
            }
            else if (joystickVertical < 0)
            {
                currentButtonIndex++;
                if (currentButtonIndex >= MenuButtons.Length)
                {
                    currentButtonIndex = 0;
                    Debug.Log(Equals(currentButtonIndex));
                }
                EventSystem.current.SetSelectedGameObject(MenuButtons[currentButtonIndex].gameObject);
            }

            if (Input.GetButtonDown("Submit"))
            {
                MenuButtons[currentButtonIndex].onClick.Invoke();
            }
            else if (Input.GetButtonDown("Cancel"))
            {
                PauseSplash.SetActive(false);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NavigationUI : MonoBehaviour
{
    public EventSystem eventSystem;
    private GameObject selectedButton;
    public GameObject[] buttons;
    public float delay = 0.5f;

    private int currentButtonIndex = 0;
    private bool isNavigating = false;

    void OnEnable()
    {
        selectedButton = buttons[0].gameObject;
        //eventSystem.firstSelectedGameObject=selectedButton;
        Debug.Log(eventSystem.firstSelectedGameObject);
        
    }

    void Update()
    {
        if (isNavigating)
        {
            return;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            currentButtonIndex--;
            if (currentButtonIndex < 0)
            {
                currentButtonIndex = buttons.Length - 1;
                Debug.Log("HOla mundo");
            }

            StartCoroutine(Navigate(currentButtonIndex));
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            currentButtonIndex++;
            if (currentButtonIndex > buttons.Length - 1)
            {
                currentButtonIndex = 0;
                Debug.Log("HOla arriba");
            }

            StartCoroutine(Navigate(currentButtonIndex));
        }

        if (Input.GetButtonDown("Cancel"))
        {
            eventSystem.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
        }
        else if (Input.GetButtonDown("Submit"))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Navigate(int index)
    {
        isNavigating = true;
        eventSystem.SetSelectedGameObject(null);
        yield return new WaitForSeconds(delay);
        eventSystem.SetSelectedGameObject(buttons[index]);
        isNavigating = false;
    }
}

*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class NavigationUI : MonoBehaviour
{
    public Button[] buttons;
    private EventSystem eventSystem;
    private int currentButton = 1;

    private void Start()
    {
        eventSystem = EventSystem.current;
    }

    private void OnEnable()
    {
        currentButton = 0;
        eventSystem.firstSelectedGameObject= buttons[currentButton].gameObject;
        Debug.Log(buttons[currentButton].gameObject.name);
    }

    private void Update()
    {
        if (Input.GetAxis("Player1_Vertical") > 0)
        {
            StartCoroutine(Navigate(1));
        }
        if (Input.GetAxis("Player1_Vertical") < 0)
        {
            StartCoroutine(Navigate(-1));
        }
        if (Input.GetButtonDown("Cancel"))
        {
            buttons[currentButton].onClick.Invoke();
        }
        if (Input.GetButtonDown("Submit"))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Navigate(int direction)
    {
        
        currentButton += direction;
        if (currentButton < 0)
        {
            currentButton = buttons.Length - 1;
        }
        if (currentButton >= buttons.Length)
        {
            currentButton = 0;
        }
        eventSystem.SetSelectedGameObject(buttons[currentButton].gameObject);
        yield return new WaitForSeconds(0.5f);
    }
}