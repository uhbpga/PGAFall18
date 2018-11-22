using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//move from one node to another using lerp
//get target position for each node
//make each node a trigger


public class AirplaneMovement : MonoBehaviour {
	private Vector3[] tempObject;
	private GameObject tempObject2;
	private Transform tempLerpObject;

	private Vector3 startingPosition;
	private Vector3 targetPosition;

	private bool isMoving;

	private float startTime;
	private float lerpValue;
	//private float interval;
	public float interval;

	private int i;
	private int count;

	// Use this for initialization
	void Start () {
		isMoving = false;
		tempObject = new Vector3[5];
		i = 0;
		count = 0;



		tempObject2 = GameObject.Find ("Airplane");
		tempLerpObject = tempObject2.transform;
		tempObject [0] = tempObject2.transform.position;

		tempObject2 = GameObject.Find ("Node1");
		tempObject [1] = tempObject2.transform.position;

		tempObject2 = GameObject.Find ("Node2");
		tempObject [2] = tempObject2.transform.position;

		tempObject2 = GameObject.Find ("Node3");
		tempObject [3] = tempObject2.transform.position;

		tempObject2 = GameObject.Find ("Node4");
		tempObject [4] = tempObject2.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving) 
		{
			//interval = 2;
			lerpValue = (Time.realtimeSinceStartup - startTime) / interval;
			Debug.Log ("LerpValue: "+ lerpValue);

			tempLerpObject.transform.position = Vector3.Lerp (startingPosition, targetPosition, lerpValue);
			count++;

			if (lerpValue >= 1) {
				//isMoving = false;
				i=i+1;
				startingPosition = tempObject [i];
				targetPosition = tempObject [i + 1];
				lerpValue = 0;
				startTime = Time.realtimeSinceStartup;

				Debug.Log("i: "+ i +"  S: "+startingPosition+" T:"+ targetPosition) ;
			}

			//if (count == 5)
			//	i = 0;
			Debug.Log("Going into Ending Condition    i:" +i);
			if (i >= 5 || lerpValue >= 2) {
				i = 0;
				isMoving = false;
				Debug.Log ("i: "+i +"lerpvalue: " + lerpValue+"I'm done! BYE!!");
				//Debug.Log ("count: " + count);
				//tempObject = tempObject + 1;
			}
		}
	}
		
	private void OnGUI(){
		if (GUI.Button(new Rect(Screen.width*0.25f, Screen.height*0.1f,Screen.width*0.2f,Screen.height*0.1f),"Move"))
		{
			startTime = Time.realtimeSinceStartup;
			isMoving = true;
			startingPosition = tempObject [i];
			targetPosition = tempObject [i + 1];
			i+=1;

			//count = 0;

			Debug.Log("i: "+ i+"  S: "+ startingPosition+" T:"+ targetPosition);
		}
	}
}
