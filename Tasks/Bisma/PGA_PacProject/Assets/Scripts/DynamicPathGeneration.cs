//PGA_ Game Dev_ Bisma Zia  5/12/2018
//HW  Path Segment Generation 
//lec 9 pooling and
//Path Segment generation using prefab pivot and endpoint logic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPathGeneration : MonoBehaviour {


    [System.Serializable]
    public class Path
    {
        public GameObject pathObj;
        public bool isActive
        {
            get
            {
                if (pathObj == null)
                    return true;

                return pathObj.activeInHierarchy;
            }
            set
            {
                pathObj.SetActive(value);
            }

        }

        public void NewInstanceData(GameObject _gameObject, float len, bool active)
        {
            this.pathObj = _gameObject;
            this.isActive = active;
        }

    }
    //****************************************
    
    Renderer rend;

    private Rect button1;
    private Vector3 tempPosition;
    private int tempInt;
    private Path tempPath;
    private GameObject tempGameObject;

    public int segmentNumber;

    public List<Path> PrefabPaths;
    private List<Path> AllPathInstances;

    //****************************************
    // Use this for initialization
    void Start()
    {

        button1 = new Rect(Screen.width * 0.5f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f);
        tempPosition = Vector3.zero;
        Pooling();

    }
	// Update is called once per frame
	void Update () {
		
	}

    // Path Generation
    void GenerateNewPath()
    { 
        if (tempGameObject.activeInHierarchy == false)
        {
            for (int i = 0; i < segmentNumber; i++)
            {
                tempPath = AllPathInstances[i];
                tempPath.isActive = true;

            }
        }
        else
        {
            tempInt = Random.Range(0,segmentNumber);
            tempGameObject = PrefabPaths[tempInt].pathObj;

            tempGameObject = GameObject.Instantiate(tempGameObject, tempPosition, Quaternion.identity);
            tempGameObject.transform.parent = this.transform;

            tempPath = new Path();
            tempPath.NewInstanceData(tempGameObject, tempPosition.z, true);
            AllPathInstances.Add(tempPath);

            tempPosition = this.tempGameObject.transform.GetChild(1).transform.position;

        }
    }

    //Pooling - storing all path prefabs in a list
    void Pooling()
    {
            AllPathInstances = new List<Path>();

            for (int i = 0, j = 0; i < segmentNumber; j++, i++)
            {
                if (j == (PrefabPaths.Count))
                {
                    j = 0;
                }

                tempGameObject = PrefabPaths[j].pathObj;

                tempGameObject = GameObject.Instantiate(tempGameObject, tempPosition, Quaternion.identity);
                tempGameObject.transform.parent = this.transform;

                tempPath = new Path();
                tempPath.NewInstanceData(tempGameObject, tempPosition.z, false);
                AllPathInstances.Add(tempPath);

                tempPosition = this.tempGameObject.transform.GetChild(1).transform.position;
            
        }


        }

    //On GUI
    private void OnGUI()
    {
        if (GUI.Button(button1, "Generate Path"))
        {
            GenerateNewPath();
        }
    }
}