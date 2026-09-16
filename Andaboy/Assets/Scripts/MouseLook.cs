using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float sensibilidade = 0.1f;

    private float rotacaoY;
    private float rotacaoX;

    void Start()
    {
        Vector3 rotacao = transform.eulerAngles;

        rotacaoY = rotacao.y;
        rotacaoX = rotacao.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();

        // Mouse esquerda/direita
        rotacaoY += mouse.x * sensibilidade;

        // Mouse cima/baixo
        rotacaoX -= mouse.y * sensibilidade;

        // Limita o olhar vertical
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        transform.rotation = Quaternion.Euler(
            rotacaoX,
            rotacaoY,
            0f
        );
    }
}
