using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float timecheckvar;
    private int timecountvar;
    private int framecountvar;
    private int totalframevar;
    private float avgframevar;
    

    private void Awake()
    {
        timecountvar = 0;
        framecountvar = 0;
        totalframevar = 0;
        timecheckvar = 0.0f;
        timecheckvar = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        framecountvar += 1;
        
        if (Time.realtimeSinceStartup - timecheckvar >= 1)
        {
            Debug.Log("Frame Count last second: " + framecountvar);
            framecountvar = 0;

            avgframevar = ((totalframevar * timecountvar) + framecountvar) / timecountvar;

            timecountvar += 1;
            Debug.Log("Average frames per second: " + avgframevar);
            timecheckvar = 0.0f;
        }
    }

}
