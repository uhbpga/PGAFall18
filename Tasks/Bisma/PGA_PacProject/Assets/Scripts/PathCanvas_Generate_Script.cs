using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PathCanvas_Generate_Script : MonoBehaviour {

    DynamicPathGeneration pathGenScript;
    Button genbutton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pooling()
    {
        pathGenScript.Pooling();

    }
    public void makePath()
    {
        pathGenScript.GenerateNewPath();
    }

}
