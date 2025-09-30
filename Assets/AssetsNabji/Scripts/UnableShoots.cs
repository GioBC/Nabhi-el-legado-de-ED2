using MoreMountains.CorgiEngine;
using UnityEngine;

public class UnableShoots : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator del objeto
    public GameObject gun; // Referencia al objeto que contiene el componente ProjectileWeapon
    private Vector3 originalPosition; // Posición original del objeto antes de ejecutar la animación
    private Quaternion originalRotation; // Rotación original del objeto antes de ejecutar la animación
    private Character character;

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // Obtener referencia al componente Animator
        gun = GetComponentInChildren<ProjectileWeapon>().gameObject;
        character = GetComponentInParent<Character>();

    }

    void Update()
    {
        /*if (character != null)
        {
            // Comprobar si la animación PushNabhi se está ejecutando
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RetroCorgiPush"))
            {
                // Deshabilitar el componente ProjectileWeapon
                gun.SetActive(false);
            }
            else
            {
                gun.SetActive(true);
            }
        }*/
        
    }
}