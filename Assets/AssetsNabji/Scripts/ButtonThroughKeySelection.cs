using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class ButtonThroughKeySelection : MonoBehaviour
{

    public string key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
      if (Input.GetKeyDown (key))
      {
         EventSystem.current.SetSelectedGameObject(
                  this.gameObject);
      }
    }
}
