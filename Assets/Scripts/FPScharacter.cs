using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScharacter : MonoBehaviour
{
    #region Variables
    
    public float moveSpeed = 12f;
    public float jumpForce = 10f;
    public float gravity = 20f;
    
    public bool canSprint = false;

    public CharacterController controller;
    public Vector3 moveDirection = Vector3.zero;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed;

        if (controller.isGrounded)
        {
            moveDirection = movement;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
    
        else
        {
        moveDirection.y -= gravity * Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);

        if (canSprint && Input.GetButton("Sprint"))
        {
            moveSpeed = 17;
            Debug.Log("Sprinting");
        }

        else
        {
        moveSpeed = 12;
        }
    }
}
