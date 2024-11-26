using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityScale = 1f;

    [Header("References")]
    public CharacterController controlJugador;
    public Animator anim;
    public Camera playerCamera;
    public Transform spawnPoint;

    private Vector3 moveDirection;
    private float yStore;

    void Start()
    {
        if (controlJugador == null)
        {
            controlJugador = GetComponent<CharacterController>();
            if (controlJugador == null)
            {
                Debug.LogError("No CharacterController component found on the player.");
            }
        }

        if (anim == null)
        {
            anim = GetComponent<Animator>();
            if (anim == null)
            {
                Debug.LogWarning("No Animator component found on the player.");
            }
        }

        if (playerCamera == null)
        {
            Debug.LogWarning("Player Camera is not assigned. Please assign a camera in the Inspector.");
        }
    }

    void Update()
    {
        HandleMovement();
        HandleGravity();
        HandleAnimation();
        AlignWithCamera();
    }

    private void HandleMovement()
    {
        yStore = moveDirection.y;

        // Get input and calculate movement
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controlJugador != null)
        {
            controlJugador.Move(moveDirection * Time.deltaTime);
        }
    }

    private void HandleGravity()
    {
        if (controlJugador != null && controlJugador.isGrounded)
        {
            moveDirection.y = 0f;

            // Jumping logic
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;

                if (anim != null)
                {
                    anim.SetTrigger("isJumping");
                }
            }
        }

        // Apply gravity
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
    }

    private void HandleAnimation()
    {
        if (anim != null)
        {
            bool isWalking = moveDirection.x != 0 || moveDirection.z != 0;
            anim.SetBool("isWalking", isWalking);
        }
    }

    private void AlignWithCamera()
    {
        if (playerCamera != null)
        {
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
        }
    }

    public void Respawn()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn Point is not set! Please assign a spawn point in the Inspector.");
            return;
        }

        controlJugador.enabled = false; // Disable control to avoid conflicts
        transform.position = spawnPoint.position;
        controlJugador.enabled = true; // Re-enable after teleporting
        moveDirection = Vector3.zero;

        Debug.Log("Player respawned successfully.");
    }
}
