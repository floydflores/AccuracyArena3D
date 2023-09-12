using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    public float crouchScale = 0.5f; // Adjust this value to determine how much the character should crouch (0.5f means half the original size)

    private Vector3 originalScale;
    private Transform pivotPoint;

    private void Start()
    {
        pivotPoint = transform.GetChild(0); // Assuming the pivot point is the first child of the character GameObject
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Check for crouch input (you can replace "Crouch" with your own input axis or button)
        if (Input.GetButtonDown("Fire2"))
        {
            Crouch();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            UnCrouch();
        }
    }

    private void Crouch()
    {
        // Scale down the character smoothly over time
        Vector3 targetScale = originalScale;
        targetScale.y *= crouchScale;
        StartCoroutine(SmoothScaleChange(targetScale));
    }

    private void UnCrouch()
    {
        // Scale back to the original size smoothly over time
        StartCoroutine(SmoothScaleChange(originalScale));
    }

    private IEnumerator SmoothScaleChange(Vector3 targetScale)
    {
        float duration = 0.2f; // Adjust the duration of the crouch animation
        float time = 0f;
        Vector3 startScale = transform.localScale;

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}