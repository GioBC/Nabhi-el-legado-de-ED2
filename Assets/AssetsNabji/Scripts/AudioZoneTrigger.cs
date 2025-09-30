using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    public class AudioZoneTrigger : MonoBehaviour
    {
        // Declara una variable para almacenar la referencia al componente AudioSource del GameObject actual
        CorgiEngineSound audioSource;

        void Start()
        {
            // Obtiene la referencia al componente AudioSource del GameObject actual
            audioSource = GetComponentInChildren<CorgiEngineSound>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // Verifica si el objeto que ha entrado en la zona es el jugador
            if (other.CompareTag("Player"))
            {
                // Reproduce el sonido de la zona
                audioSource.Play();
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            // Verifica si el objeto que ha salido de la zona es el jugador
            if (other.CompareTag("Player"))
            {
                // Detiene el sonido de la zona
                audioSource.Stop();
            }
        }
    }

}
