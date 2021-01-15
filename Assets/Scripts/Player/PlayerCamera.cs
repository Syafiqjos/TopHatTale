using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public float followRatio;
    public Vector2 followOffset;

    public SpriteRenderer vignette;
    private float vignetteAlpha = 0;
    private float vignetteAlphaTarget = 0;
    public float fadeRatio = 0.2f;

    public bool IsFadeIn
    {
        get
        {
            return vignetteAlpha >= 0.92f;
        }
    }

    public bool IsFadeOut
    {
        get
        {
            return vignetteAlpha <= 0.08f;
        }
    }

    void Start()
    {
        followRatio = Mathf.Clamp(followRatio, 0, 1.0f) ;
        vignetteAlpha = 0;
    }

    void Update()
    {
        if (player)
        {
            Vector3 somePosition = Vector2.Lerp(transform.position, (Vector2)player.position + followOffset, followRatio);
            somePosition.z = -10;

            transform.position = somePosition;
        }

        VignetteFadeControl();
    }

    public void FadeIn()
    {
        vignetteAlphaTarget = 1.0f;
        Debug.Log("FadingIn");
    }

    public void FadeOut()
    {
        vignetteAlphaTarget = 0.0f;
        Debug.Log("FadingOut");
    }

    void VignetteFadeControl()
    {
        vignetteAlpha = Mathf.Lerp(vignetteAlpha, vignetteAlphaTarget, fadeRatio);
        vignette.color = new Color(vignette.color.r, vignette.color.g, vignette.color.b, vignetteAlpha);
    }
}
