using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeController : MonoBehaviour
{

    [SerializeField] Image image;
    [SerializeField] bool visibleOnStart;
    [SerializeField] bool fadeOutOnStart;
    public static ScreenFadeController instance;

    [SerializeField] float fadingSpeed;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        image.gameObject.SetActive(visibleOnStart);
        if (fadeOutOnStart) Fade(false);
    }

    public Coroutine Fade(bool fadeOut)
    {
        return StartCoroutine(FadeCorout(fadeOut));
    }

    IEnumerator FadeCorout(bool fadeOut)
    {
        image.gameObject.SetActive(true);
        float t = 0;
        Color color = Color.black;
        float startAlpha = fadeOut ? 0.0f : 1.0f;
        float targetAlpha = fadeOut ? 1.0f : 0.0f;
        while (t < 1.1f)
        {
            t += Time.deltaTime * fadingSpeed;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            image.color = color;
            yield return null;
        }

        if (!fadeOut) gameObject.SetActive(false);
    }
}
