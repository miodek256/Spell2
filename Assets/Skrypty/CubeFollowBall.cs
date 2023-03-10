using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollowBall : MonoBehaviour
{
    public GameObject ball; // kula, do kt�rej przypinamy sze�cian
    public Vector3 offset; // przesuni�cie sze�cianu wzgl�dem kuli

    private Quaternion initialRotation; // pocz�tkowa rotacja sze�cianu wzgl�dem �wiata

    void Start()
    {
        // zapisanie pocz�tkowej rotacji sze�cianu
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // ustawienie pozycji sze�cianu wzgl�dem kuli z uwzgl�dnieniem przesuni�cia
        transform.position = ball.transform.position + offset;

        // przywr�cenie pocz�tkowej rotacji sze�cianu wzgl�dem �wiata
        transform.rotation = initialRotation;
    }
}