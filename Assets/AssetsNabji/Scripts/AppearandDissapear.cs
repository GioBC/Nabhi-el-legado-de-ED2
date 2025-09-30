using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearandDissapear : MonoBehaviour
{
    [Tooltip("Target object to turn on/off (NOT this object or its parents!")]
    public GameObject target;

    [Tooltip("Seconds to wait between activating / deactivating the object")]
    public float interval = 1f;

    // IEnumerator makes this run as a coroutine we can suspend & resume with yield.
    IEnumerator Start()
    {
        if (target == gameObject)
            Debug.LogError("ActiveAlternator cannot target itself and still re-activate");


        // Infinite loop! But it's OK, because we'll tell it to take breaks.
        while (true)
        {

            // This passes control back to the engine so it can draw the frame,
            // and asks to resume this method on the next line after some time.
            yield return new WaitForSeconds(interval);

            // If the object was active, set it inactive, and vice versa.
            target.SetActive(!target.activeSelf);

            // Then loop to wait, and alternate again, forever.
        }

    }
}
