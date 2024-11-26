using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controlJugador;
    public float gravityScale;

    private Vector3 moveDirection;
    private float yStore;

    public Animator anim;
    public Camera playerCamera;  
    public Transform spawnPoint;

    void Start()
    {
        if (controlJugador == null)
        {
            controlJugador = GetComponent<CharacterController>();
        }

        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned. Please assign a Camera in the Inspector.");
        }
    }

    void Update()
    {
        yStore = moveDirection.y;

        // Movement
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        // Apply movement
        controlJugador.Move(moveDirection * Time.deltaTime);

        // Animation
        bool isWalking = moveDirection.x != 0 || moveDirection.z != 0;
        anim.SetBool("isWalking", isWalking);

  

 if (controlJugador.isGrounded)
{
    // Reset vertical velocity when grounded
    moveDirection.y = 0f;

    // Check if Jump button is pressed
    if (Input.GetButtonDown("Jump"))
    {
        moveDirection.y = jumpForce;
        anim.SetTrigger("isJumping");  // Use SetTrigger instead of SetBool to trigger the jump animation
    }
}


        // Gravity
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        // Camera alignment
        if (playerCamera != null)
        {
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Water"))
        {
            Debug.Log("The player has touched water");
            Respawn();
        }
    }

    void Respawn()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn Point not set! Please assign a spawn point in the Inspector.");
            return;
        }

        controlJugador.enabled = false; 
        transform.position = spawnPoint.position; 
        controlJugador.enabled = true; 
        moveDirection = Vector3.zero;
    }





}