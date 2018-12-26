using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public DisguiseMechanicScript dMScript;

    public GameObject character;
    //{
    //    set
    //    {
    //        character = gameObject.GetComponent<CharacterController>();
    //    }
    //        }
    public float speed;

    private Vector2 chPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //press "I" to turn on/off disguise
        if (Input.GetKeyDown(KeyCode.I))
            dMScript.TurnOnDisuguise();
        else //Movement Input
            Movement();    

	}

    void Movement()
    {
        Vector2 temp = Vector2.zero; 
        chPosition = Vector2.zero;
        chPosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            chPosition = Vector2.up;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            chPosition = Vector2.down;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            chPosition = Vector2.left;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow))
            chPosition = Vector2.right;

        temp.x = character.transform.position.x;
        temp.y = character.transform.position.y;


        chPosition *= speed * Time.deltaTime  ;
        chPosition += temp;

        //character.Move(chPosition);
        character.transform.position = Vector2.Lerp(character.transform.position, chPosition, 1);
    }
}