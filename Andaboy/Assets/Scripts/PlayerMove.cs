using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;

    private Vector3 direction;

    void Update()
    {
        // Faz o personagem olhar para a mesma direção horizontal da câmera
        float cameraY = Camera.main.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, cameraY, 0f);

        direction = Vector3.zero;

        // W - frente
        if (Keyboard.current[Key.W].isPressed)
        {
            direction += transform.forward;
        }

        // S - trás
        if (Keyboard.current[Key.S].isPressed)
        {
            direction -= transform.forward;
        }

        // D - direita
        if (Keyboard.current[Key.D].isPressed)
        {
            direction += transform.right;
        }

        // A - esquerda
        if (Keyboard.current[Key.A].isPressed)
        {
            direction -= transform.right;
        }

        // Impede que diagonal seja mais rápida
        direction = Vector3.ClampMagnitude(direction, 1f);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(
            direction.x * speed,
            rb.linearVelocity.y,
            direction.z * speed
        );
    }
}