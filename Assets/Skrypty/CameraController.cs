using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // obiekt, za kt�rym b�dzie pod��a� kamera
    public float cameraHeight = 10f; // wysoko�� kamery wzgl�dem obiektu
    public float cameraDistance = 20f; // odleg�o�� kamery od obiektu
    public float cameraAngle = 45f; // k�t kamery

    private Vector3 cameraOffset; // odleg�o�� pomi�dzy kamer� a obiektem
    private float mouseX, mouseY; // pozycja myszki
    private float mouseSensitivity = 150f; // czu�o�� myszki

    void Start()
    {
        // obliczanie pocz�tkowej odleg�o�ci pomi�dzy kamer� a obiektem
        cameraOffset = new Vector3(0, cameraHeight, -cameraDistance);

        // ustawienie pocz�tkowej pozycji kamery
        transform.position = target.transform.position + cameraOffset;

        // ustawienie pocz�tkowej pozycji myszki
        mouseX = 0f;
        mouseY = 0f;
    }

    void Update()
    {
        // odczyt pozycji myszki
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ograniczenie k�t�w kamery
        mouseY = Mathf.Clamp(mouseY, 0f, 30f);

        // obliczanie nowego wektora kierunku kamery
        Vector3 cameraDirection = Quaternion.Euler(-mouseY, mouseX, 0f) * Vector3.forward;

        // obliczanie nowej pozycji kamery wzgl�dem obiektu
        cameraOffset = Quaternion.Euler(cameraAngle, 0f, 0f) * cameraDirection * cameraDistance;

        // ustawienie pozycji kamery
        transform.position = target.transform.position + cameraOffset;

        // ustawienie punktu, na kt�ry kamera patrzy
        transform.LookAt(target.transform.position);
    }
}