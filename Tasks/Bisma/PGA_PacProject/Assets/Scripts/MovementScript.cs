﻿//lec 4 Lerp Movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
	public Transform tempObject;
	public Vector3 targetPositon;
	//Vector3 direction;
	//public float speed;

	private Vector3 startingPosition;
	private float startTime;

	private float lerpValue;
	public float Interval;

	public AnimationCurve Curve;

	private bool isMoving = false;
	// Use this for initialization
	void Start ()
	{
		//tempObject = GameObject.Find("Movingobject");
		//tempObject = GameObject.FindGameObjectWithTag("MovingObjectTag");
		//tempObject = GameObject.FindObjectOfType<MovingItemScript>().gameObject;
	}

	// Update is called once per frame
	void Update () {
		//if (isMoving)
		//      {
		//          tempObject.transform.position += direction * speed * Time.deltaTime;
		//      }
		if (isMoving)
		{
			lerpValue = (Time.realtimeSinceStartup - startTime) / Interval;
			Debug.Log ("Lerp: "+lerpValue);
			//tempObject.transform.position = Vector3.Lerp(startingPosition, targetPositon, lerpValue);
			tempObject.transform.position = Vector3.Lerp(startingPosition, targetPositon, Curve.Evaluate(lerpValue));
			if (lerpValue >= 1)
			{
				Debug.Log("Ending time : " + Time.realtimeSinceStartup);
				isMoving = false;
			}
		}
	}

	private void LateUpdate()
	{
		//if (isMoving)
		//{
		//    if (Vector3.Distance(tempObject.transform.position,targetPositon) < 0.1f)
		//    {
		//        isMoving = false;
		//    }
		//}
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(100,100,100,100),"Move"))
		{
			//tempObject.SetActive(false);
			//tempObject.DebugMessage();
			//tempObject.position = targetPositon;
			//tempObject.transform.position = new Vector3(-5, 0, 0);
			//direction = (targetPositon - tempObject.transform.position).normalized;
			startTime = Time.realtimeSinceStartup;
			startingPosition = tempObject.transform.position;
			Debug.Log("Starting time : " + Time.realtimeSinceStartup);
			isMoving = true;
		}
	}
}
