using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip footstepSound; // Audio de las pisadas
    AudioSource audioSource; // Fuente de audio

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtiene el componente AudioSource del enemigo
    }

    // Update is called once per frame
    void Update()
    {
        // Si el enemigo está en movimiento, reproduce el sonido de las pisadas
        if (GetComponent<EnemyMovement>().isMoving)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }
}