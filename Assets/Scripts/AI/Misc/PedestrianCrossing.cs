using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianCrossing : MonoBehaviour
{
    private bool isCrossing;
    private void OnTriggerStay(Collider other)
    {
        print("Stay");
        if (other.CompareTag("Pedestrian"))
            isCrossing = true;
        
        if (other.CompareTag("Vehicle"))
        {
            if (isCrossing)
                other.GetComponent<AIBrain>().IsWaiting = true;
            else
                other.GetComponent<AIBrain>().IsWaiting = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Exit");

        if (other.CompareTag("Pedestrian"))
            isCrossing = false;
    }
}
