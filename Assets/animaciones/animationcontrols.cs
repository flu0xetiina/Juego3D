using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;           // Velocidad de movimiento
    public float jumpForce = 5f;       // Fuerza de salto
    public float gravity = 9.81f;      // Gravedad personalizada

    private CharacterController controller;
    private Vector3 moveDirection;

    // Verifica si el jugador está en el suelo usando un raycast
    bool isGrounded;

    void Start()
    {
        // Obtén el componente CharacterController
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verifica si el jugador está en el suelo
        if (controller.isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = -2f; // Mantener al jugador en el suelo
        }

        // Movimiento en los ejes X y Z (local)
        Vector3 forward = transform.forward; // Direccion adelante/atrás
        Vector3 right = transform.right;     // Direccion izquierda/derecha

        // Input basado en las teclas A,W,S,D
        float horizontal = Input.GetAxisRaw("Horizontal"); // Movimiento lateral (A/D)
        float vertical = Input.GetAxisRaw("Vertical");     // Movimiento adelante/atrás (W/S)

        // Combinar direcciones para calcular movimiento
        Vector3 move = (forward * vertical + right * horizontal).normalized;

        // Aplicar movimiento
        controller.Move(move * speed * Time.deltaTime);

        // Salto
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        // Aplicar gravedad
        moveDirection.y -= gravity * Time.deltaTime;

        // Movimiento en el eje Y
        controller.Move(new Vector3(0, moveDirection.y, 0) * Time.deltaTime);
    }

}