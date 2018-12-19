using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisguiseMechanicScript : MonoBehaviour {

    public BoxCollider _collider;
    public Vector3 collSize;
    public Vector3 collNormSize;

	// Use this for initialization
	void Start () {
        _collider.size = collNormSize;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TurnOnDisuguise()
    {
        if (_collider.size == collSize)
        {
            _collider.size = collNormSize;
            Debug.Log("Disguise is turned on");
        }
        else if (_collider.size != collSize)
        {
            _collider.size = collSize;
            Debug.Log("Disguise is turned off");
        }
    }
    
}
