using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollowBall : MonoBehaviour
{
    public GameObject ball; // kula, do której przypinamy sześcian
    public Vector3 offset; // przesunięcie sześcianu względem kuli

    private Quaternion initialRotation; // początkowa rotacja sześcianu względem świata

    void Start()
    {
        // zapisanie początkowej rotacji sześcianu
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // ustawienie pozycji sześcianu względem kuli z uwzględnieniem przesunięcia
        transform.position = ball.transform.position + offset;

        // przywrócenie początkowej rotacji sześcianu względem świata
        transform.rotation = initialRotation;
    }
}