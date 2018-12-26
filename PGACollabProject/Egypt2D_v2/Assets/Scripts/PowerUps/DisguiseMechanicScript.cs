using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisguiseMechanicScript : MonoBehaviour {

  
    public  CircleCollider2D[] Enemycolliders;
    public float collDisSize;
    public float collNormSize;

	// Use this for initialization
	void Start () {
        
        foreach ( CircleCollider2D collider2D in Enemycolliders )
        {

            collider2D.radius = collNormSize; ;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TurnOnDisuguise()
    {
        float tempSize = 0;

        if (Enemycolliders[0].radius == collDisSize)
        {
            tempSize = collNormSize;
            Debug.Log("Disguise is turned OFF");
        }
        else if (Enemycolliders[0].radius == collNormSize)
        {
            tempSize = collDisSize;
            Debug.Log("Disguise is turned ON");
        }

        foreach (CircleCollider2D collider2D in Enemycolliders)
        {

            collider2D.radius = tempSize; ;
        }
    }
    
}
