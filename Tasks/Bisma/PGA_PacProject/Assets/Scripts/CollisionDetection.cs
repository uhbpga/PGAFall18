//Lec 5
// Collision Detection


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("OnCollisionEnter:Gameobject:" + collision.gameObject.name);
	}

	private void OnCollisionStay(Collision collision)
	{
		Debug.Log("OnCollisionStay:Gameobject:" + collision.gameObject.name);
	}

	private void OnCollisionExit(Collision collision)
	{
		Debug.Log("OnCollisionExit:Gameobject:" + collision.gameObject.name);

	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter:Gameobject:" + other.gameObject.name);
	}
}
