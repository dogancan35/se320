using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterContoller : MonoBehaviour
{

    private Vector3 currentJumpVelocity;
    private bool isJumping;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        float speed = 10;

        Vector3 moveVelocity = transform.forward * Input.GetAxis("Vertical") * speed;

        float turnDegreesInSecond = 90;

        float horizontalInput = Input.GetAxis("Horizontal");

        if(!Mathf.Approximately(horizontalInput, 0))
        {
            transform.Rotate(0, horizontalInput * turnDegreesInSecond * Time.deltaTime, 0);
        }
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                isJumping = true;
                currentJumpVelocity = Vector3.up * 5;
            }
        }
        if(isJumping)
        {
            controller.Move((moveVelocity + currentJumpVelocity) * Time.deltaTime);

            currentJumpVelocity += Physics.gravity * Time.deltaTime;

            if(controller.isGrounded)
            {
                isJumping = false;
            }
        }
        else
        {
            controller.SimpleMove(moveVelocity);
        }
    }
}