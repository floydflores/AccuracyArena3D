using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityOff : MonoBehaviour
{
    public CanvasGroup imageToHide;

    public void HideImage()
    {
        imageToHide.alpha = 0; // Hide the Image component
    }
}
