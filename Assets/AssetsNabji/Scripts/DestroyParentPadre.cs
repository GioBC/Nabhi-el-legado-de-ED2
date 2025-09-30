using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentPadre : MonoBehaviour

{
    public GameObject child;

    void Update()
    {
        if (child == null)
        {
            Destroy(gameObject);
        }
    }
}

