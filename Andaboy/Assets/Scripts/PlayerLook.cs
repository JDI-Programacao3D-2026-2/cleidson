using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float sensibilidade = 100f;
    public Transform cameraTransform;

    private float rotacaoX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();

        float mouseX = mouse.x * sensibilidade * Time.deltaTime;
        float mouseY = mouse.y * sensibilidade * Time.deltaTime;

        // Esquerda e direita: gira o PLAYER inteiro
        transform.Rotate(Vector3.up * mouseX);

        // Cima e baixo: gira somente a câmera
        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
    }
}
