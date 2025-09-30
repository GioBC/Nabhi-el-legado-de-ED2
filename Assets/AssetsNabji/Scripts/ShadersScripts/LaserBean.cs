using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBean : MonoBehaviour
{

    public Camera cam;
    public LineRenderer lineRenderer;

    public Transform startPoint; 
    public Transform endPoint;
    

    private Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {
        //DisableLaser();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Player1_ShootAxis"))
        {
            EnableLaser();
        }*/

       
            UpdateLaser();
       

        /*if (Input.GetButtonUp("Player1_ShootAxis"))
        {
            DisableLaser();
        }*/

        //RotateToMouse();
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    void UpdateLaser()
    {
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        lineRenderer.SetPosition(0, endPoint.position);
        lineRenderer.SetPosition(1, startPoint.position);

        //Vector3 direction = lineRenderer.SetPosition(0, endPoint.position);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)startPoint.position, endPoint.position/*.normalized, endPoint.position.magnitude*/);

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    void RotateToMouse()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotation;

    }
}
