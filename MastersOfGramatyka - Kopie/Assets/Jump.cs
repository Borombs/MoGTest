using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public Transform groundCheck;
    private readonly float groundDistance = 0.4f;
    public LayerMask groundMask; 
    public bool isGrounded;

    /*public Transform collisionCheck;
    public float collisionDistance = 0.1f;
    public LayerMask collisionMask;
    private bool isColliding;*/

    private CharacterController controller;
    private Animator anim;
    public ThirdPersonMovement tpm;

    private float verticalVelocity;
    [SerializeField] private float gravity = 30f;
    [SerializeField] private float jumpForce = 10f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        /*isColliding = Physics.CheckSphere(collisionCheck.position, collisionDistance, collisionMask); 
        das hier is noch experimentiell, ist dafür da falls der charakter an decken stuck ist*/
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && !tpm.crouching)   
        {   //die vertikale beschleunigung besteht aus der negativen gravitation (-23f), das heißt der spieler wird durch diese kraft nach unten gedrückt
            verticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetButton("Jump"))
            {
                anim.SetBool("isJumping", true);
                verticalVelocity = jumpForce;
            }
            else
            {
                anim.SetBool("isJumping", false);
            }

        }
        //wenn der spieler nicht am boden ist, dann wird die vertikale beschleunigung durch die gravitation schnell verringert, so dass der spieler wieder auf dem boden ist
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
    
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);

    }

}
