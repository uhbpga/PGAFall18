using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController characterController_Player;
    private float gravity = 2;
    private float jump = 1;
    private Vector3 moveDirection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveDirection = Vector3.zero;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    moveDirection += characterController_Player.transform.forward;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    moveDirection -= characterController_Player.transform.forward;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    moveDirection += characterController_Player.transform.right;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    moveDirection -= characterController_Player.transform.right;
        //}
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= Time.deltaTime;

        if (characterController_Player.isGrounded)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                moveDirection += Vector3.up * jump;
            }
        }

        moveDirection += Vector3.down * gravity * Time.deltaTime;
        characterController_Player.Move(moveDirection);
	}
}
