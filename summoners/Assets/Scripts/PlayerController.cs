using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public LayerMask interactable;
    bool grounded;


    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public bool isVR;
    public GameObject XR;
    Vector3 moveDirection;

    Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        if (!isVR)
        {
            Destroy(XR);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        SpeedControl();
        //Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //Handle drag
        if (grounded)
        {
            //Debug.Log("Grounded");
            rb.drag = groundDrag;
        }
        else
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, interactable);
            if (grounded)
            {
                //Debug.Log("Grounded");
                rb.drag = groundDrag;
            }
            else
                rb.drag = 0;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    //Take horizontal and vertical input from player
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        //Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //Add force to player
        rb.AddForce(moveDirection.normalized * moveSpeed * 10);
    }
    //Limit players speed to moveSpeed variable
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
