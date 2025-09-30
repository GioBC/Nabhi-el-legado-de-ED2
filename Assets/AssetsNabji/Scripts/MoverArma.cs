using MoreMountains.CorgiEngine;
using UnityEngine;

public class MoverArma : MonoBehaviour
{

    public float amplitude; // Amplitud del movimiento
    public float speed; // Velocidad del movimiento
    private float minY; // Límite inferior de movimiento
    private float maxY; // Límite superior de movimiento

    private Animator animator; // Referencia al componente Animator del objeto
    private float startingY; // Posición inicial en Y del objeto

    void Start()
    {
        animator = GetComponentInParent<Animator>(); // Obtener referencia al componente Animator
        startingY = 10;//transform.position.y; // Guardar posición inicial en Y
        
    }

    void Update()
    {
        // Obtener estado actual de la animación
        string currentAnimation = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        // Utilizar un switch para determinar el movimiento según la animación
        switch (currentAnimation)
        {
            case "IdleNabhi":
                MoveSin();
                break;
            case "ShootUp":
                MoveUp();
                break;
            case "ShootDown":
                MoveDown();
                break;
            case "Walk2Nabhi":
                MoveDiagonal();
                break;
            default:
                break;
        }
    }

    void MoveSin()
    {
        minY = startingY - 5;
        maxY = startingY + 5;
        float y = amplitude * Mathf.Sin(Time.time * speed) + startingY;
        y = Mathf.Clamp(y, minY, maxY);
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }

    void MoveUp()
    {
        minY = startingY +5;
        maxY = startingY + 12;
        float y = transform.position.y - 2; // Calcular posición en Y sumando 2
        y = Mathf.Clamp(y, minY, maxY); // Aplicar límites inferiores y superiores
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z); // Actualizar posición del objeto
    }

    void MoveDown()
    {
        minY = startingY - 5;
        maxY = startingY + 5;
        float y = transform.position.y + 2; // Calcular posición en Y restando 2
        y = Mathf.Clamp(y, minY, maxY); // Aplicar límites inferiores y superiores
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z); // Actualizar posición del objeto
    }

    void MoveDiagonal()
    {
        minY = startingY - 5;
        maxY = startingY + 5;
        float y = amplitude * Mathf.Sin(Time.time * speed) + startingY;
        y = Mathf.Clamp(y, minY, maxY);
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }
}

