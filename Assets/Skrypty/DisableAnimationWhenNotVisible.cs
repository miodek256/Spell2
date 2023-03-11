using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimationWhenNotVisible : MonoBehaviour
{
    private Animator animator;
    private new Renderer renderer;
    private AnimationScript animationScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        animationScript = GetComponent<AnimationScript>();
    }

    void Update()
    {
        // Sprawdzenie, czy obiekt jest widoczny przez kamer�
        if (renderer.isVisible)
        {
            // Je�li obiekt jest widoczny, w��cz skrypt animacji
            animationScript.enabled = true;
        }
        else
        {
            // Je�li obiekt nie jest widoczny, wy��cz skrypt animacji
            animationScript.enabled = false;
        }
    }
}