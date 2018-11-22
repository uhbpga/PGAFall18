using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rect MoveStartButtonRect;
    public Rigidbody rigidbody_player;

    public float Speed;

    private void Awake()
    {
        MoveStartButtonRect = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody_player.AddForce(rigidbody_player.transform.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody_player.AddForce((rigidbody_player.transform.forward * -1) * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody_player.AddForce(rigidbody_player.transform.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody_player.AddForce((rigidbody_player.transform.right * -1) * Speed * Time.deltaTime);
        }
    }

    //private void OnGUI()
    //{
    //    if (GUI.Button(MoveStartButtonRect,"Add Force"))
    //    {
    //        rigidbody_player.AddForce(rigidbody_player.transform.forward * Speed * Time.deltaTime);
    //        Debug.Log("velocity:" + rigidbody_player.velocity);
    //    }
    //}
}
