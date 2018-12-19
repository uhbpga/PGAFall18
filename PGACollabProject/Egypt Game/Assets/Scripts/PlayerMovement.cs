using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
      public float speed;
  //    private Rigidbody rb;


	// Use this for initialization
	void Start () {
     // rb = GetComponent<Rigidbody>();
		
	}


    void FixedUpdate () {
        float h = Input.GetAxis("Horizontal") * speed *Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(h, 0.0f, v));
      //  rb.AddForce(transform.forward * speed);
        //Vector3 move = new Vector3(h, 0.0f, v);
       // rb.AddForce(move * speed);

    }
}
