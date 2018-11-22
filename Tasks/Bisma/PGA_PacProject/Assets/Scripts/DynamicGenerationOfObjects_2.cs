using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGenerationOfObjects_2 : MonoBehaviour
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
        public int height;
        public Vector3 lastPosition;

    }

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
        public InstanceData(Type _type, GameObject _instance, bool _isActive)
        {
            type = _type;
            instance = _instance;
            isActive = _isActive;
        }

    }
    //=======================
    public Camera camRef;

    private Rect ButtonRect1;
    private Rect ButtonRect2;
    private Rect ButtonRect3;
    
    public List<Data> PrefabData;
    List<InstanceData> AllInstances;
       
    private Data tempData;
    private GameObject tempObject;
    private InstanceData tempInstanceData;

    private Data selectedData;

    public Vector3 spacing;

    //------------------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {

        ButtonRect1 = new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f);
        ButtonRect2 = new Rect(Screen.width * 0.3f, 0, Screen.width * 0.2f, Screen.height * 0.1f);
        ButtonRect3 = new Rect(Screen.width * 0.6f, 0, Screen.width * 0.2f, Screen.height * 0.1f);
        InitializePooling();
    }

    //=========================================
    void InitializePooling()
    {

        AllInstances = new List<InstanceData>();
        for (int i = 0; i < PrefabData.Count; i++)
        {
            tempData = PrefabData[i];
            for (int j = 0; j < tempData.numberOfExpectedUsage; j++)
            {
                tempObject = GameObject.Instantiate(tempData.Object, Vector3.zero, Quaternion.identity);
                tempObject.transform.parent = this.transform;
                AllInstances.Add(new InstanceData(tempData.type, tempObject, false));
            }

        }

    }

    //========================================

    void CreateNewObject(Type _type)
    {

        tempInstanceData = AllInstances.Find(item => (item.type == _type && item.isActive == false));
        if (tempInstanceData == null)
        {
            tempObject = GameObject.Instantiate(PrefabData.Find(item => item.type == _type).Object , Vector3.zero,Quaternion.identity) ;
            tempObject.transform.parent = this.transform;
            tempInstanceData = new InstanceData(_type, tempObject, false);
            AllInstances.Add(tempInstanceData);
        }

        tempInstanceData.isActive = true;
        tempData = PrefabData.Find(item => item.type == _type);
        tempInstanceData.instance.transform.position = tempData.lastPosition + (Vector3.up * tempData.height);
        tempData.lastPosition += spacing;
    }


    //========================================
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 clickPosition = Input.mousePosition;
            Ray rayToCast = camRef.ScreenPointToRay(clickPosition);
            RaycastHit hit;
            if (Physics.Raycast(rayToCast, out hit))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }

    //========================================
    public void OnGUI()
    {
        if (GUI.Button(ButtonRect1, "Generate Capsule"))
        {
            CreateNewObject(Type.Capsule);
        }
        if (GUI.Button(ButtonRect2, "Generate Cube"))
        {
            CreateNewObject(Type.Cube);
        }
        if (GUI.Button(ButtonRect3, "Generate Circle"))
        {
            CreateNewObject(Type.Sphere);
        }
    }
}