using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {
    CombatStatus abc = new CombatStatus();
    //public static bool CombatMod;
    // Use this for initialization
    void Start () {
        //CombatMod = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Guard Spotted " + collision.gameObject.name + " \t  Collider Radious at " + gameObject.GetComponent<CircleCollider2D>().radius);
        //CombatMod = true;
        abc.SetCombatMod(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //CombatMod = false;
        abc.SetCombatMod(false);
    }

}
