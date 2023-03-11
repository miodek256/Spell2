using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimationWhenNotVisible : MonoBehaviour
{
    private Animator animator;
    private AnimationScript animationScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        animationScript = GetComponent<AnimationScript>();
    }

    void Update()
    {
        // Pobranie pozycji obiektu w przestrzeni œwiata
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        // Sprawdzenie, czy obiekt jest widoczny na ekranie kamery
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        // Sprawdzenie, czy skrypt animacji jest przypisany do obiektu
        if (animationScript != null)
        {
            // Jeœli obiekt jest widoczny, w³¹cz skrypt animacji
            if (onScreen)
            {
                animationScript.enabled = true;
            }
            // Jeœli obiekt nie jest widoczny, wy³¹cz skrypt animacji
            else
            {
                animationScript.enabled = false;
            }
        }
    }
}