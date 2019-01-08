using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatus {
    public static bool CombatMod;
	// Use this for initialization
	void Start () {
        CombatMod = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetCombatMod(bool abc)
    {
        CombatMod = abc;
    }
    public bool GetCombatMod()
    {
        return CombatMod;
    }
}
