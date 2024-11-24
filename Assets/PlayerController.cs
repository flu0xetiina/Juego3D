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

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {   
        yStore = moveDirection.y;

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * moveSpeed;
        controlJugador.Move(moveDirection * Time.deltaTime);
        moveDirection.y = yStore;

        bool isWalking = moveDirection.x != 0 || moveDirection.z != 0;

        anim.SetBool("isWalking", isWalking);

        if (Input.GetButtonDown("Jump")) 
        {
            moveDirection.y = jumpForce;
           anim.SetTrigger("isJumping");
        }

        // Gravity
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        controlJugador.Move(moveDirection * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
    }
}
