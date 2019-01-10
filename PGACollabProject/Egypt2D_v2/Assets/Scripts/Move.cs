using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public DisguiseMechanicScript dMScript;
    //public InteractionScript combat;
    //InteractionScript combat = new InteractionScript();
    public Animator MC_Anim;

    CombatStatus combat = new CombatStatus();

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
        combat.SetCombatMod(false);
    }
    
	
	// Update is called once per frame
	void Update () {

        MC_Anim.SetInteger("PlayerDirection", 0);

        if (combat.GetCombatMod())
        {
            Debug.Log("Combat Mod is On");
        }
        //press "I" to turn on/off disguise
        if (Input.GetKeyDown(KeyCode.I))
        {
            dMScript.TurnOnDisuguise();
        }
        else //Movement Input
            Movement();    

	}

    void Movement()
    {
        Vector2 temp = Vector2.zero; 
        chPosition = Vector2.zero;
        chPosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            chPosition = Vector2.up;
            MC_Anim.SetInteger("PlayerDirection", 2);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            chPosition = Vector2.down;
            MC_Anim.SetInteger("PlayerDirection", 1);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        { chPosition = Vector2.left;
            MC_Anim.SetInteger("PlayerDirection", 3);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        { chPosition = Vector2.right;
            MC_Anim.SetInteger("PlayerDirection", 4);
        }
        else if (Input.GetKey(KeyCode.H) && combat.GetCombatMod())
        { Debug.Log("Player Attack");
        }

        temp.x = character.transform.position.x;
        temp.y = character.transform.position.y;


        chPosition *= speed * Time.deltaTime  ;
        chPosition += temp;

        //character.Move(chPosition);
        character.transform.position = Vector2.Lerp(character.transform.position, chPosition, 1);
    }
}