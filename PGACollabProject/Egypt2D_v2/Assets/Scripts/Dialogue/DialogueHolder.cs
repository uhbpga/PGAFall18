using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueHolder : MonoBehaviour
{
    public State startingState;

    //------------
    public string dialogue;
    private DialogueManager dManager;


    //*************************
    // Use this for initialization
    void Start()
    {
        dManager = FindObjectOfType<DialogueManager>();
    }

    //-------------

    // Update is called once per frame
    void Update()
    {

    }

    //--------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger zone entered");
    }
    
    //------------------------
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger zone exit");
    }

    //------------------------

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                dManager.ShowBox(startingState);
            }
            
        }
    }
}
