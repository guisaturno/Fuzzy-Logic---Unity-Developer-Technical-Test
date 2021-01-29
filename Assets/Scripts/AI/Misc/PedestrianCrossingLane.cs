using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianCrossingLane : MonoBehaviour
{
    private PedestrianCrossing _pedestrianCrossing;

    private void Start()
    {
        _pedestrianCrossing = GetComponentInChildren<PedestrianCrossing>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            if (_pedestrianCrossing.IsCrossing)
                other.GetComponent<AIBrain>().IsWaiting = true;
            else
                other.GetComponent<AIBrain>().IsWaiting = false;
        }
    }
}
