using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controlJugador;
    public float gravityScale;

    private Vector3 moveDirection;
    private float yStore;

    // Reference to the Animator
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure Animator is assigned
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {   
        // Store vertical movement
        yStore = moveDirection.y;

        // Movement
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * moveSpeed;
        controlJugador.Move(moveDirection * Time.deltaTime);
        moveDirection.y = yStore;

        // Check if the player is walking (moving on the X or Z axis)
        bool isWalking = moveDirection.x != 0 || moveDirection.z != 0;

        // Update the IsWalking animation parameter
        anim.SetBool("isWalking", isWalking);

        // Jump
        if (Input.GetButtonDown("Jump")) 
        {
            moveDirection.y = jumpForce;
           anim.SetTrigger("isJumping");
        }

        // Gravity
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        controlJugador.Move(moveDirection * Time.deltaTime);
    }
}
