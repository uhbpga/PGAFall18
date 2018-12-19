<<<<<<< HEAD
using System.Collections;
=======
﻿using System.Collections;
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2
using System.Collections.Generic;
using UnityEngine;

public class DynamicGenerationOfPath : MonoBehaviour {

    Renderer rend;
    [System.Serializable]
    public class PathData
    {
        public GameObject pathObj;
        // public Vector3 length; 
        private bool isActive;

        public PathData(GameObject _gameObject , bool _vbool)
        {
            pathObj = _gameObject;
            isActive = _vbool;

        }
        public void makeActive(bool val)
        {
            isActive = val;
        }
    }

    private Vector3 spacing;
    public int NumberOfSegments;

    public List<PathData> PrefabPathData;
    private List<PathData> AllPathInstances;

    private PathData tempPath;
    private GameObject tempObject;

    private Rect buttonRect;
    //----------------------------------------------------------------------
	// Use this for initialization
	void Start () {
        spacing = new Vector3(0,0,10);

        buttonRect = new Rect(Screen.width * 0.5f , Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f);
    }
	
    //==================================
	// Update is called once per frame
	void Update () {
		
	}
    
    //====================================
    void GeneratePath()
    {
        if (AllPathInstances.Count < NumberOfSegments)
        {
            for (int i = 0, j = 0; i < NumberOfSegments; j++, i++)
            {
                Debug.Log("Number of segment " + i);
                if (j >= PrefabPathData.Count)
                { j = 0; }
                Debug.Log("Creating path " + j);

                tempObject = new GameObject();
                tempObject = GameObject.Instantiate(tempObject, Vector3.zero, Quaternion.identity);
                // tempPath.pathObj = tempObject;
                tempPath = new PathData(tempObject, true);
                // tempPath.pathObj = tempObject;
                tempPath.pathObj = PrefabPathData[j].pathObj;
                tempPath.makeActive(true);
                //tempPath = GameObject.Instantiate(tempPath.pathObj, Vector3.zero, Quaternion.identity);
                // tempPath.pathObj = PrefabPathData[j].pathObj;
                //  tempPath.isActive = true;
                AllPathInstances.Add(new PathData(tempPath.pathObj, true));
                // AllPathInstances.Add(PrefabPathData[j]);
                /*       
                          tempObject = GameObject.Instantiate(tempPath.pathObj, Vector3.zero, Quaternion.identity);
                          //tempObject.transform.parent = this.transform;
                          //  AllPathInstances.Add(new InstanceData(tempObject, true));
                          AllPathInstances.Add(new PathData(tempObject,true));
              */
            }
        }
        else
        {

        }
    }
    //=================================
    //void GeneratePath()
    //{
    //    // make all paths active for Number of segments
    //    // if more, then make anew gameobject and active it
    //    // and add it the List All Instances ,ik
    //}
    //=================================

    void OnGUI()
    {
        if (GUI.Button(buttonRect, "Generate Path"))
        {
            Debug.Log("Button pressed");
            GeneratePath();
           
        }
    }
}
