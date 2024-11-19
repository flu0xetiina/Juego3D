using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controlJugador;
    public float gravityScale;

    private Vector3 moveDirection;
    private float yStore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   yStore = moveDirection.y;

        //movimiento
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * moveSpeed;
        controlJugador.Move(moveDirection * Time.deltaTime);
        moveDirection.y = yStore;

        //salto
        if (Input.GetButtonDown("Jump")){
            moveDirection.y = jumpForce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        controlJugador.Move(moveDirection * Time.deltaTime);
    }
}
