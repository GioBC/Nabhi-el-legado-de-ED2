using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizadordeLayers : MonoBehaviour
{
    public int capa;
    private SpriteRenderer layer;
    // Start is called before the first frame update
    void Start()
    {
        layer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (layer.sortingOrder != 19)
        {
            layer.sortingOrder = 19;
        }
    }
}
