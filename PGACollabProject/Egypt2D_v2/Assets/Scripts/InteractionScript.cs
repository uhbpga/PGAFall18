using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Guard Spotted " + collision.gameObject.name + " \t  Collider Radious at " + gameObject.GetComponent<CircleCollider2D>().radius);
    }
}
