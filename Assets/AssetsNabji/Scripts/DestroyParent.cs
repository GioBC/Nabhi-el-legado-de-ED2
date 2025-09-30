using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    public GameObject parent;
    public GameObject particleSystemPrefab;

    public void DestroyChildObject()
    {
        // Crea una instancia de las particulas en la posición del hijo
        GameObject particleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

        // Destruye el hijo y las particulas después de un tiempo determinado
        Destroy(gameObject);
        Destroy(particleSystem, 5f);
    }
}
