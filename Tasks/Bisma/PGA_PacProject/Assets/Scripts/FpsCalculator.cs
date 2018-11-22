using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCalculator : MonoBehaviour {
	private float fpsNum;
	private float fpsAvg;
	private float count;
	private float fpsSum;


	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		fpsNum = 0;
		fpsAvg = 0;
		count = 0;
		fpsSum = 0;
	}

	// Update is called once per frame
	void Update () {
		//while(Time.deltaTime == 0.00) {
			
			fpsNum = 1 / Time.deltaTime;
			Debug.Log ("Fps Count: " + fpsNum);

			count = count + 1;
			fpsSum = fpsSum + fpsNum;
			fpsAvg = fpsSum / count;
			Debug.Log ("Fps Average Count: " + fpsAvg);
		//}
	}
}
