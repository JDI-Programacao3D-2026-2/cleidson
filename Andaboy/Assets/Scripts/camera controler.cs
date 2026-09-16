using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float sensibilidade = 0.2f;

    private float rotacaoVertical = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        Vector2 mouse = Mouse.current.delta.ReadValue();

        // Esquerda / direita
        float rotacaoHorizontal = mouse.x * sensibilidade;

        transform.Rotate(0f, rotacaoHorizontal, 0f);

        // Cima / baixo
        rotacaoVertical -= mouse.y * sensibilidade;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -85f, 85f);

        cameraTransform.localRotation =
            Quaternion.Euler(rotacaoVertical, 0f, 0f);
    }
}
