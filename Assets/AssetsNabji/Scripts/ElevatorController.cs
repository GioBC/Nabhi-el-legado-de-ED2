using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importante para manejar UI

public class ElevatorController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public KeyCode activationKey = KeyCode.E; // Tecla para activar el ascensor, configurable desde el Inspector
    public GameObject uiMessage; // Aquí asignarás el texto o imagen
    public GameObject uiMessage2; // Aquí asignarás el texto o imagen
    private bool isMoving = false;
    private Transform target;
    private bool inRange = false;

    void Start()
    {
        // Asegurarse de que el mensaje esté oculto al iniciar
        uiMessage.gameObject.SetActive(false);
        uiMessage2.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            // Mostrar el canvas cuando el jugador está en rango, pero solo si el ascensor no está en movimiento
            if (!isMoving)
            {
                uiMessage.gameObject.SetActive(true);
                uiMessage2.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            // Ocultar el mensaje cuando el jugador sale del rango
            uiMessage.gameObject.SetActive(false);
            uiMessage2.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Detectar si el jugador está en el rango y presiona el botón para mover el ascensor
        if (inRange && Input.GetKeyDown(activationKey) && !isMoving)
        {
            if (Vector3.Distance(transform.position, pointA.position) < 0.01f)
            {
                target = pointB;
            }
            else if (Vector3.Distance(transform.position, pointB.position) < 0.01f)
            {
                target = pointA;
            }

            isMoving = true;
            uiMessage.gameObject.SetActive(false); // Ocultar el mensaje cuando el ascensor se mueve
            uiMessage2.gameObject.SetActive(false); // Ocultar el mensaje cuando el ascensor se mueve
        }

        // Mover el ascensor si está activado
        if (isMoving)
        {
            MoveElevator();
        }


    }

    void MoveElevator()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Detener el ascensor cuando llega al destino
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            isMoving = false;

            // Mostrar el canvas otra vez si el jugador está dentro del rango
            if (inRange)
            {
                uiMessage.gameObject.SetActive(true);
                uiMessage2.gameObject.SetActive(true);
            }
        }
    }
}



