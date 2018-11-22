using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGenerationOfPath : MonoBehaviour {

    [System.Serializable]
    public class PathData
    {
        public GameObject path;
       // public Vector3 length; 
        private bool isActive
        {
            set
            {
                ///
            }
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
        InitiatePooling();

        buttonRect = new Rect(Screen.width * 0.5f , Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f);
    }
	
    //==================================
	// Update is called once per frame
	void Update () {
		
	}

    //=================================
    void InitiatePooling()
    {
        for (int i = 0, j=0 ; i < NumberOfSegments; j++, i++)
        {
            if (j >= PrefabPathData.Count)
            { j = 0; }
            //tempObject
            //tempPath = GameObject.Instantiate(tempObject,Vector3.zero , Quaternion.identity);
            //tempPath = PrefabPathData[j];
            //AllPathInstances.Add(tempPath);
            AllPathInstances.Add(PrefabPathData[j]);
        }
    }
    //=================================

    void GeneratePath()
    {
        // make all paths active for Number of segments
        // if more, then make anew gameobject and active it
        // and add it the List All Instances ,ik
    }
    //=================================

    void OnGUI()
    {
        if (GUI.Button(buttonRect, "Generate Path"))
        {
            GeneratePath();
        }
    }
}
