using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarShakras : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("PrefShakraRaiz", 0);
            PlayerPrefs.SetInt("PrefShakraCorazon", 0);
            PlayerPrefs.SetInt("PrefShakraGarganta", 0);
            PlayerPrefs.SetInt("PrefShakraPlexoSolar", 0);
            PlayerPrefs.SetInt("PrefShakraSacro", 0);
            PlayerPrefs.SetInt("PrefShakraTercerOjo", 0);
        }


    }
}
