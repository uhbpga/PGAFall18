using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//When player interacts with NPC
public class PlayerCollision : MonoBehaviour {
    public GameObject instructionBox1;
    public GameObject instructionBox2;
    public GameObject instructionBox3;

    public GameObject myAnimation1;
    public GameObject myAnimation3;

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("We hit " + other.name);
            if (other.tag == "NPC" && other.name == "NPC1")
            {
                instructionBox1.SetActive(true);
                myAnimation1.gameObject.GetComponent<Animator>().enabled = false;
            }

            if (other.tag == "NPC" && other.name == "NPC2")
            {
                instructionBox2.SetActive(true);
            }

            if (other.tag == "NPC" && other.name == "NPC3")
            {
                myAnimation3.gameObject.GetComponent<Animator>().enabled = false;
                instructionBox3.SetActive(true);
            }
    }
    // void OnCollisionEnter(Collision collisionInfo)
    //{
    //    Debug.Log("We hit " + collisionInfo.collider.name);
    //    if(collisionInfo.collider.tag == "NPC" && collisionInfo.collider.name == "NPC1")
    //    {
    //        instructionBox1.SetActive(true);
    //        myAnimation1.gameObject.GetComponent<Animator>().enabled = false;
    //    }

    //    if (collisionInfo.collider.tag == "NPC" && collisionInfo.collider.name == "NPC2")
    //    {
    //        instructionBox2.SetActive(true);
    //    }

    //    if (collisionInfo.collider.tag == "NPC" && collisionInfo.collider.name == "NPC3")
    //    {
    //        myAnimation3.gameObject.GetComponent<Animator>().enabled = false;
    //        instructionBox3.SetActive(true);
    //    }


    //}

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("We have left " + other.name);
        if (other.tag == "NPC" && other.name == "NPC1")
        {
            instructionBox1.SetActive(false);
            myAnimation1.gameObject.GetComponent<Animator>().enabled = true;
        }

        if (other.tag == "NPC" && other.name == "NPC2")
        {
            instructionBox2.SetActive(false);
        }

        if (other.tag == "NPC" && other.name == "NPC3")
        {
            instructionBox3.SetActive(false);
            myAnimation3.gameObject.GetComponent<Animator>().enabled = true;
        }
    }
//    private void OnCollisionExit(Collision collisionInfo)
//    {
//        Debug.Log("We have left " + collisionInfo.collider.name);
//        if(collisionInfo.collider.tag == "NPC" && collisionInfo.collider.name == "NPC1")
//        {
//            instructionBox1.SetActive(false);
//            myAnimation1.gameObject.GetComponent<Animator>().enabled = true;
//        }

//        if (collisionInfo.collider.tag == "NPC" && collisionInfo.collider.name == "NPC2")
//        {
//            instructionBox2.SetActive(false);
//        }

//        if (collisionInfo.collider.tag == "NPC" && collisionInfo.collider.name == "NPC3")
//        {
//            instructionBox3.SetActive(false);
//            myAnimation3.gameObject.GetComponent<Animator>().enabled = true;
//        }
//    }
}
