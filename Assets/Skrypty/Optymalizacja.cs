using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optymalizacja : MonoBehaviour
{
    private Animator animator;
    private Renderer renderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Sprawdzenie, czy obiekt jest widoczny przez kamerê
        if (renderer.isVisible)
        {
            // Jeœli obiekt jest widoczny, w³¹cz animacjê
            animator.enabled = true;
        }
        else
        {
            // Jeœli obiekt nie jest widoczny, wy³¹cz animacjê
            animator.enabled = false;
        }

        // Sprawdzenie, czy obiekt ma tag "diament"
        if (gameObject.CompareTag("diament"))
        {
            // Jeœli obiekt ma tag "diament", sprawdŸ, czy jest widoczny przez kamerê
            if (renderer.isVisible)
            {
                // Jeœli obiekt jest widoczny, w³¹cz skrypt animacji
                AnimationScript.enabled = true;
            }
            else
            {
                // Jeœli obiekt nie jest widoczny, wy³¹cz skrypt animacji
                AnimationScript.enabled = false;
            }
        }
    }
}