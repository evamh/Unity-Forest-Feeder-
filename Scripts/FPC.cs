using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**

    First person controller script
    Can configure the movement speed, the jump speed and the mouseSensitivity
    ChatGPT helped with this

**/
public class FPC : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float mouseSensitivity = 2.0f;
    [SerializeField] float jumpSpeed = 5.0f;

    CharacterController controller;
    float verticalRotation = 0f;
    float horizontalRotation = 0f;
    Vector3 velocity = Vector3.zero;
    float gravity = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true; 
             
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed;

        // Apply jump
        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpSpeed;
        }
        
        // Apply gravity
        if(!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        } 

        // Apply horizontal movement
        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement = transform.rotation * movement;
        controller.Move(movement * Time.deltaTime);

        // Apply vertical movement
        verticalRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(-verticalRotation, transform.localEulerAngles.y, 0f);

        horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, horizontalRotation, 0f);

        // Apply velocity
        controller.Move(velocity * Time.deltaTime);
    }
}
