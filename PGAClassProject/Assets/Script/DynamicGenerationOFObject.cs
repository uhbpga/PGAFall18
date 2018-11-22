using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGenerationOFObject : MonoBehaviour
{
    public enum Type
    {
        Cube = 0,
        Sphere,
        Capsule
    }
    [System.Serializable]
    public class Data
    {
        public Type type;
        public GameObject Object;
        public int numberOfExpectedUsage;
        public float Height;
        public Vector3 LastPosition;
    }
    [System.Serializable]
    public class InstanceData
    {
        public Type type;
        public GameObject instance;
        public bool isActive
        {
            get
            {
                if (instance == null)
                    return true;
                 
                return instance.activeInHierarchy;
            }
            set
            {
                instance.SetActive(value);
            }
        }

        public InstanceData(Type _type,GameObject _instance,bool _isActive)
        {
            this.type = _type;
            this.instance = _instance;
            this.isActive = _isActive;
        }

    }

    public Camera camRef;

    public List<Data> PrefabData;

    private List<InstanceData> AllInstances;
    
    public Transform Parent;
    private Rect buttonRect;
    private Rect buttonRect1;
    private Rect buttonRect2;
    public int numberOfObjectToGenerate;
    public Vector3 startPosition;
    public Vector3 spacing;
    

    private Data tempData;
    private GameObject tempObject;
    private InstanceData tempInstanceData;

    // Use this for initialization
    void Start () {
        buttonRect = new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f);
        buttonRect1 = new Rect(Screen.width * 0.3f, 0, Screen.width * 0.2f, Screen.height * 0.1f);
        buttonRect2 = new Rect(Screen.width * 0.6f, 0, Screen.width * 0.2f, Screen.height * 0.1f);
        InitializePooling();
    }

    void InitializePooling()
    {
        AllInstances = new List<InstanceData>();

        for(int i = 0; i < PrefabData.Count; i++)
        {
            tempData = PrefabData[i];
            PrefabData[i].LastPosition = startPosition;
            for(int j = 0; j < tempData.numberOfExpectedUsage;j++)
            {
                tempObject = GameObject.Instantiate(tempData.Object, Vector3.zero, Quaternion.identity);
                tempObject.transform.parent = this.transform;
                AllInstances.Add(new InstanceData(tempData.type,tempObject,false));
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 clickPosition = Input.mousePosition;
            Ray rayToCast = camRef.ScreenPointToRay(clickPosition);
            RaycastHit hit;
            if (Physics.Raycast(rayToCast,out hit))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
	}

    private Data selectedData;

    void CreateNewObject(Type _type)
    {
        tempInstanceData = AllInstances.Find(item => (item.type == _type && item.isActive == false));
        if (tempInstanceData == null)
        {
            tempObject = GameObject.Instantiate(PrefabData.Find(item => item.type == _type).Object, Vector3.zero, Quaternion.identity);
            tempObject.transform.parent = this.transform;
            tempInstanceData = new InstanceData(_type, tempObject, false);
            AllInstances.Add(tempInstanceData);
;        }
        tempInstanceData.isActive = true;
        tempData = PrefabData.Find(item => item.type == _type);
        tempInstanceData.instance.transform.position = tempData.LastPosition + (Vector3.up * tempData.Height);
        tempData.LastPosition += spacing;
    }

    private void OnGUI()
    {
        if (GUI.Button(buttonRect,"Generate Cube"))
        {
            CreateNewObject(Type.Cube);
        }
        if (GUI.Button(buttonRect1, "Generate Sphere"))
        {
            CreateNewObject(Type.Sphere);
        }
        if (GUI.Button(buttonRect2, "Generate capsule"))
        {
            CreateNewObject(Type.Capsule);
        }
    }
}
