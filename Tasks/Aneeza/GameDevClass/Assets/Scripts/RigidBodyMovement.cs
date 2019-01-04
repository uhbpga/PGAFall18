using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    private Rect movingStartButtonRect;
    public Rigidbody rigidBody_cube;

    public float speed;

    private void Awake()
    {
        movingStartButtonRect = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.2f);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("GetKeydown called");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("GetKey called");
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(movingStartButtonRect, "Add Force"))
        {
            rigidBody_cube.AddForce(rigidBody_cube.transform.forward * speed * Time.deltaTime);
        }
    }
}
