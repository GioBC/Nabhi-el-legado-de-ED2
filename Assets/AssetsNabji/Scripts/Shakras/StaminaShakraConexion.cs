using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaShakraConexion : MonoBehaviour
{
    private bool _habilitarShakraConexion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided game object has the DamageOnTouch component
        //DamageOnTouch damageOnTouch = other.GetComponent<DamageOnTouch>();
        _habilitarShakraConexion = other.GetComponent<ShakraConexion>().habilitarShakraConexion;
        _habilitarShakraConexion = true;


    }
}
