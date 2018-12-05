using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour {

    public GameObject path1;
    public GameObject path2;

    private GameObject pivot;
    private GameObject endpoint;
    private GameObject tempGameObject;

    public Vector3 tempTransform;

    private Rect button1;

    Renderer rend;

    
	// Use this for initialization
	void Start () {

        button1 = new Rect(Screen.width * 0.5f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f);

     //   path1 = GameObject.Instantiate(path1, Vector3.zero, Quaternion.identity);        
        pivot = new GameObject("pivot");
        endpoint = new GameObject("Endpoint");

        rend = path1.GetComponent<Renderer>();
        tempTransform = Vector3.zero;
        tempTransform.z = endpoint.transform.position.z + rend.bounds.size.z;
        endpoint.transform.position = tempTransform;

        pivot.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        endpoint.transform.SetPositionAndRotation(tempTransform, Quaternion.identity);

        tempTransform = pivot.transform.position + tempTransform/2;

        path1 = GameObject.Instantiate(path1, tempTransform, Quaternion.identity);
     //   path1.transform.position = Vector3.Lerp(Vector3.zero, tempTransform, 0);


        path1.transform.SetParent(pivot.transform);        
        endpoint.transform.SetParent(pivot.transform);

        Debug.Log("Endpoint: " + endpoint.transform.position);
    }
    //change Position pivot
    void Generate()
    {
        pivot = new GameObject("pivot");
        pivot.transform.position = endpoint.transform.position;
        tempTransform = endpoint.transform.position;

        endpoint = new GameObject("Endpoint");

        rend = path2.GetComponent<Renderer>();

        tempTransform.z = tempTransform.z + rend.bounds.size.z;
        endpoint.transform.position = tempTransform;

        tempTransform = Vector3.zero;
        tempTransform.z = pivot.transform.position.z + rend.bounds.size.z / 2;

        path2 = GameObject.Instantiate(path2, tempTransform, Quaternion.identity);

        path2.transform.SetParent(pivot.transform);
        endpoint.transform.SetParent(pivot.transform);

        Debug.Log("Endpoint: " + endpoint.transform.position);
    }

    //On GUI Elements
    private void OnGUI()
    {
        if (GUI.Button(button1, "generate"))
        {
            Generate();

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
