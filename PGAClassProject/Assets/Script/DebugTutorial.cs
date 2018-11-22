using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Logging message");
        Debug.LogWarning("Logging warning");
        Debug.LogError("Logging Error");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
