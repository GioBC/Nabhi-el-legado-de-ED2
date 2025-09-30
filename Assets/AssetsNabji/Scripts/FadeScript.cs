using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{
    public float fadeDuration;
    public string playerTag;

    private float elapsedTime;
    private bool fadingIn;
    private bool fadingOut;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        elapsedTime = 0;
        fadingIn = false;
        fadingOut = false;
    }

    void Update()
    {
        if (fadingOut)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            spriteRenderer.color = Color.Lerp(Color.clear, Color.white, t);

            if (t >= 1)
            {
                fadingOut = false;
            }
        }
        else if (fadingIn)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            spriteRenderer.color = Color.Lerp(Color.white, Color.clear, t);

            if (t >= 1)
            {
                fadingIn = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            elapsedTime = 0;
            fadingIn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            elapsedTime = 0;
            fadingOut = true;
        }
    }
}

