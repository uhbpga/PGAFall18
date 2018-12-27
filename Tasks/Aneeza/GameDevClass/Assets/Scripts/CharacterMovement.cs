using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public CharacterController characterController_Player;
    private float gravity = 2;
    private float jump = 15;
    private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = Vector3.zero;

        //for keyboard
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection += characterController_Player.transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDirection -= characterController_Player.transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection += characterController_Player.transform.right;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDirection -= characterController_Player.transform.right;
        }

        //for joystick
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDirection *= Time.deltaTime;

        //for jump
        if (Input.GetKeyUp(KeyCode.Space))
        {
            moveDirection += Vector3.up * jump;
            if (characterController_Player.isGrounded) //so it can't jump in the air
            {
               
            }
        }

       moveDirection = characterController_Player.transform.forward;
       moveDirection += Vector3.down * gravity * Time.deltaTime;
       characterController_Player.Move(moveDirection);

		
	}
}
