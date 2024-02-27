using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    private Transform camTransform;

    private float speedCurrect;
    private float speedWalk;
    private float speedSmooth;

    public float turnSmoothTime = 0.1f;
    private float turnSpeedVelocity;

    private Vector3 moveVel = Vector3.zero;

    private const float gravity = 8.9f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        camTransform = Camera.main.transform;
        speedWalk = 5f;
    }

    private void FixedUpdate()
    {
        
            moveVel.y = -gravity;
        
        characterController.Move(moveVel * Time.deltaTime);
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y;

        speedCurrect = speedWalk;
        Vector3 moveDir = Vector3.zero;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeedVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            
        }
        
        characterController.Move(moveDir.normalized * speedWalk * Time.deltaTime);
        
    }

    public void Jump()
    {
        
            moveVel.y += Mathf.Sqrt(3f*gravity);
        
    }
}
