//Charcter Movemnt and Action on Input
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public DisguiseMechanicScript dMScript;
    public CharacterController characterController_Player;
    public float speed;
    private Vector3 moveDirection;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
          dMScript.TurnOnDisuguise() ;
        else
            MoveOnInput();
    }

    //
    void MoveOnInput()
    {
        moveDirection = Vector3.zero;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += characterController_Player.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= characterController_Player.transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += characterController_Player.transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= characterController_Player.transform.right;
        }
        moveDirection = moveDirection * speed * Time.deltaTime;
        characterController_Player.Move(moveDirection);

    }
}
