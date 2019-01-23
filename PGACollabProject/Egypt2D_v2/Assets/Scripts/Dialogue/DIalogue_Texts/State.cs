using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(1, 5)] [SerializeField] string dialogueText;

    [SerializeField] List<State> nextStates;

    //-----------------
	public string GetStateDialogue()
    {
        return dialogueText;
    }
    //------------------
    public List<State> GetNextState()
    {
        return nextStates;
    }
}
