using System.Collections;
using UnityEngine;

public class AppearAfterTime : MonoBehaviour
{
    public GameObject objectToAppear;
    public float timeToAppear = 5.0f;

    private void Start()
    {
        objectToAppear.SetActive(false);
        Invoke("MakeObjectAppear", timeToAppear);
    }

    private void MakeObjectAppear()
    {
        objectToAppear.SetActive(true);
    }
}
