using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform tempObject;
 //   public Vector3 targetPositon;
    Vector3 direction;
    public float speed;

    private Vector3 startingPosition;
    private float startTime;

    private float lerpValue;
    public float Interval;

    public AnimationCurve Curve;

    public Vector3[] targetPositions = new [] { new Vector3 (3f, 5.5f,-1.5f), new Vector3 (-4f, 0.71f, -5), new Vector3 (5f, 0.84f, 3f)};
    public Vector3[] startPositions = new[] { new Vector3(0f, 0f, -6.4f), new Vector3(3f, 5.5f, -1.5f), new Vector3(-4f, 0.71f, -5) };

    private bool isMoving = false;
    // Use this for initialization
    void Start()
    {
        //tempObject = GameObject.Find("Movingobject");
        //tempObject = GameObject.FindGameObjectWithTag("MovingObjectTag");
        //tempObject = GameObject.FindObjectOfType<MovingItemScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isMoving)
        //      {
        //          tempObject.transform.position += direction * speed * Time.deltaTime;
        //      }
        
        if (isMoving)
        {
            lerpValue = ((Time.realtimeSinceStartup - startTime) / Interval) * 180;
            for (int i = 0; i < 3; i++)
            {
                tempObject.transform.position = Vector3.Lerp(startPositions[i], targetPositions[i], Curve.Evaluate(Mathf.Abs(Mathf.Sin(Mathf.PI * lerpValue / 180))));
                
            }
        }
    }

    private void LateUpdate()
    {
        //if (isMoving)
        //{
        //    if (Vector3.Distance(tempObject.transform.position,targetPositon) < 0.1f)
        //    {
        //        isMoving = false;
        //    }
        //}
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.1f ,  Screen.width * 0.1f , Screen.height * 0.1f), "Move"))
        {
            //tempObject.SetActive(false);
            //tempObject.DebugMessage();
            //tempObject.position = targetPositon;
            //tempObject.transform.position = new Vector3(-5, 0, 0);
            //direction = (targetPositon - tempObject.transform.position).normalized;
            startTime = Time.realtimeSinceStartup;
            startingPosition = tempObject.transform.position;
            Debug.Log("Starting time : " + Time.realtimeSinceStartup);
            isMoving = true;
        }
    }
}
