using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public State startingState;

    List<State> nextStates;
    private int listcount = 0;

    State state;
    private int count = 0;

    public GameObject dBox;
    public Text dText1;
    
    public bool dialogueActive;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  var nextStates = state.GetNextState();

        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (count == listcount)
            {
                dBox.SetActive(false);
                dialogueActive = false;

            }
            else
            {
                
                state = nextStates[count];
                dText1.text = state.GetStateDialogue();
                count++;
            }
        }

    }

    public void ShowBox(State startingState)
    {
        dialogueActive = true;
        dBox.SetActive(true);
      //  dText1.text = dialogue;

        dText1.text = startingState.GetStateDialogue();

        state = startingState;
        nextStates = state.GetNextState();
        listcount = nextStates.Count;
        count = 0;

    }
}
