using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianCrossing : MonoBehaviour
{
    private bool isCrossing;

    public bool IsCrossing => isCrossing;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pedestrian"))
            isCrossing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pedestrian"))
            isCrossing = false;
    }
}
