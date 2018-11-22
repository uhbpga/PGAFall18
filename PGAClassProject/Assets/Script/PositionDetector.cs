using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDetector : MonoBehaviour
{
    private bool privateVar;
    protected bool protectedVar;
    public bool publicVar;
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    private void Start()
    {
        Debug.Log("Start");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void Update()
    {
        
    }
    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width*0.25f,Screen.height*0.1f,Screen.width*0.2f,Screen.height*0.1f),"Button"))
        {

        }
    }
}
