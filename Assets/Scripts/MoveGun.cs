using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    public float gunSpeed;
    private Rigidbody2D rb;
    private Vector2 gunDirection;
    [SerializeField] private Vector3 joysticTransform;
    private Vector3 posInicial;
    // Start is called before the first frame update

    /*private void Awake()
    {
        joysticTransform = GameObject.Find("JoystickKnob").transform.position;
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posInicial = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Player1_Horizontal");
        float directionY = Input.GetAxisRaw("Player1_Vertical");

        Debug.Log(directionX);

        gunDirection = new Vector2(directionX, directionY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(gunDirection.x * gunSpeed, gunDirection.y * gunSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LimitGun")
        {
            Vector3 temPos = transform.position;
            if (Vector3.Distance(transform.position, posInicial) > Vector3.Distance(temPos, posInicial))
            {
                transform.position = temPos;
            }

        }
    }
}
