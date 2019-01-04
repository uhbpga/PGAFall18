using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {
    float timeDifference = 0.0f;
	
	// Update is called once per frame
	void Update () {
        timeDifference += (Time.deltaTime - timeDifference) * 0.1f;
        Debug.Log("The current frame rate is: " + timeDifference);
	}
}
