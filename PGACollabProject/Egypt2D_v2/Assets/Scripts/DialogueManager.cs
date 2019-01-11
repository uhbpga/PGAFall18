﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
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
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogueActive = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText1.text = dialogue;
       
    }
}
