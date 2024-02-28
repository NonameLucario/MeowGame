using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Camera cam;

    private Vector3 playerVelocity;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    public float turnSmoothTime = 0.1f;
    private float turnSpeedVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        //Add move
        if(moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeedVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(move * speed * Time.deltaTime);
        }
        //controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        //Add gravity
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        }
    }
}
