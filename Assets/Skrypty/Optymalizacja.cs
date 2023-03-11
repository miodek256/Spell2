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
        // Sprawdzenie, czy obiekt jest widoczny przez kamer�
        if (renderer.isVisible)
        {
            // Je�li obiekt jest widoczny, w��cz animacj�
            animator.enabled = true;
        }
        else
        {
            // Je�li obiekt nie jest widoczny, wy��cz animacj�
            animator.enabled = false;
        }

        // Sprawdzenie, czy obiekt ma tag "diament"
        if (gameObject.CompareTag("diament"))
        {
            // Je�li obiekt ma tag "diament", sprawd�, czy jest widoczny przez kamer�
            if (renderer.isVisible)
            {
                // Je�li obiekt jest widoczny, w��cz skrypt animacji
                AnimationScript.enabled = true;
            }
            else
            {
                // Je�li obiekt nie jest widoczny, wy��cz skrypt animacji
                AnimationScript.enabled = false;
            }
        }
    }
}