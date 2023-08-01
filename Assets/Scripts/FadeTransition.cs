using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration of the fade transition in seconds

    private CanvasGroup canvasGroup;

    private void Start()
    {
        // Get the CanvasGroup component on the current GameObject
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Calculate the current alpha value based on the elapsed time
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha value is set to 0 at the end of the fade
        canvasGroup.alpha = 0f;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Calculate the current alpha value based on the elapsed time
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha value is set to 1 at the end of the fade
        canvasGroup.alpha = 1f;
    }
}
