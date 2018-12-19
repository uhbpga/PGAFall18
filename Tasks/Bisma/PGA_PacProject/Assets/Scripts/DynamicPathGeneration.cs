<<<<<<< HEAD
//PGA_ Game Dev_ Bisma Zia  5/12/2018
=======
﻿//PGA_ Game Dev_ Bisma Zia  5/12/2018
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2
//HW  Path Segment Generation 
//lec 9 pooling and
//Path Segment generation using prefab pivot and endpoint logic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class DynamicPathGeneration : MonoBehaviour
{
=======
public class DynamicPathGeneration : MonoBehaviour {
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2


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
<<<<<<< HEAD

    Renderer rend;

  //  private Rect button1;
=======
    
    Renderer rend;

    private Rect button1;
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2
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

<<<<<<< HEAD
       // button1 = new Rect(Screen.width * 0.5f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f);
=======
        button1 = new Rect(Screen.width * 0.5f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f);
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2
        tempPosition = Vector3.zero;
        Pooling();

    }
<<<<<<< HEAD
    // Update is called once per frame
    void Update()
    {

    }

    // Path Generation
    public void GenerateNewPath()
    {
=======
	// Update is called once per frame
	void Update () {
		
	}

    // Path Generation
    void GenerateNewPath()
    { 
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2
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
<<<<<<< HEAD
            tempInt = Random.Range(0, segmentNumber);
=======
            tempInt = Random.Range(0,segmentNumber);
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2
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
<<<<<<< HEAD
    public void Pooling()
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

//    //On GUI
//    private void OnGUI()
//    {
//        if (GUI.Button(button1, "Generate Path"))
//        {
//            GenerateNewPath();
//        }
//    }
=======
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
>>>>>>> 426981912bedcc8569b3d9a55e031a7024fdd3d2
}