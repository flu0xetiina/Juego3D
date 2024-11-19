using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundDistance = 0.3f; // Distancia para el raycast
    public LayerMask groundMask;        // Capa para detectar el suelo

    public bool IsGrounded()
    {
        // Raycast hacia abajo para verificar si el jugador está en el suelo
        return Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);
    }
}