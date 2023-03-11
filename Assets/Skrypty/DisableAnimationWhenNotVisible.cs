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
        // Sprawdzenie, czy obiekt jest widoczny przez kamerê
        if (renderer.isVisible)
        {
            // Jeœli obiekt jest widoczny, w³¹cz skrypt animacji
            animationScript.enabled = true;
        }
        else
        {
            // Jeœli obiekt nie jest widoczny, wy³¹cz skrypt animacji
            animationScript.enabled = false;
        }
    }
}