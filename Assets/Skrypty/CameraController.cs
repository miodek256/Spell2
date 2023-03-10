using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // obiekt, za którym bêdzie pod¹¿aæ kamera
    public float cameraHeight = 10f; // wysokoœæ kamery wzglêdem obiektu
    public float cameraDistance = 20f; // odleg³oœæ kamery od obiektu
    public float cameraAngle = 45f; // k¹t kamery

    private Vector3 cameraOffset; // odleg³oœæ pomiêdzy kamer¹ a obiektem
    private float mouseX, mouseY; // pozycja myszki
    private float mouseSensitivity = 150f; // czu³oœæ myszki

    void Start()
    {
        // obliczanie pocz¹tkowej odleg³oœci pomiêdzy kamer¹ a obiektem
        cameraOffset = new Vector3(0, cameraHeight, -cameraDistance);

        // ustawienie pocz¹tkowej pozycji kamery
        transform.position = target.transform.position + cameraOffset;

        // ustawienie pocz¹tkowej pozycji myszki
        mouseX = 0f;
        mouseY = 0f;
    }

    void Update()
    {
        // odczyt pozycji myszki
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ograniczenie k¹tów kamery
        mouseY = Mathf.Clamp(mouseY, 0f, 30f);

        // obliczanie nowego wektora kierunku kamery
        Vector3 cameraDirection = Quaternion.Euler(-mouseY, mouseX, 0f) * Vector3.forward;

        // obliczanie nowej pozycji kamery wzglêdem obiektu
        cameraOffset = Quaternion.Euler(cameraAngle, 0f, 0f) * cameraDirection * cameraDistance;

        // ustawienie pozycji kamery
        transform.position = target.transform.position + cameraOffset;

        // ustawienie punktu, na który kamera patrzy
        transform.LookAt(target.transform.position);
    }
}