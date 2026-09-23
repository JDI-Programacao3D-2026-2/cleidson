using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("Alvo")]
    public Transform player;

    [Header("Câmera")]
    public float distance = 5f;
    public float height = 2f;

    [Header("Mouse")]
    public float mouseSensitivity = 0.1f;
    public float minVerticalAngle = -30f;
    public float maxVerticalAngle = 60f;

    private float rotationX = 10f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (player != null)
        {
            rotationY = player.eulerAngles.y;
        }
    }

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("CameraFollow: Player não foi configurado.");
            return;
        }

        // Pega o mouse diretamente pelo novo Input System
        if (Mouse.current != null)
        {
            Vector2 mouseInput = Mouse.current.delta.ReadValue();

            float mouseX = mouseInput.x * mouseSensitivity;
            float mouseY = mouseInput.y * mouseSensitivity;

            // Movimento horizontal
            rotationY += mouseX;

            // Movimento vertical
            rotationX -= mouseY;

            // Limita a câmera para cima e para baixo
            rotationX = Mathf.Clamp(
                rotationX,
                minVerticalAngle,
                maxVerticalAngle
            );
        }

        // Rotação da câmera
        Quaternion rotation = Quaternion.Euler(
            rotationX,
            rotationY,
            0f
        );

        // Ponto onde a câmera acompanha o jogador
        Vector3 targetPosition =
            player.position + Vector3.up * height;

        // Coloca a câmera atrás do jogador
        Vector3 cameraPosition =
            targetPosition -
            rotation * Vector3.forward * distance;

        transform.position = cameraPosition;
        transform.rotation = rotation;
    }
}