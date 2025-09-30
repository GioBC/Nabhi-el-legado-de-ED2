using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparecer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponent<Renderer>().enabled = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }
}
