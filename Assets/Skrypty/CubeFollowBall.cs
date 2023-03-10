using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollowBall : MonoBehaviour
{
    public GameObject ball; // kula, do której przypinamy szeœcian
    public Vector3 offset; // przesuniêcie szeœcianu wzglêdem kuli

    private Quaternion initialRotation; // pocz¹tkowa rotacja szeœcianu wzglêdem œwiata

    void Start()
    {
        // zapisanie pocz¹tkowej rotacji szeœcianu
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // ustawienie pozycji szeœcianu wzglêdem kuli z uwzglêdnieniem przesuniêcia
        transform.position = ball.transform.position + offset;

        // przywrócenie pocz¹tkowej rotacji szeœcianu wzglêdem œwiata
        transform.rotation = initialRotation;
    }
}