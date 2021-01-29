using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PedestrianCrossingLane : MonoBehaviour
{
    private PedestrianCrossing _pedestrianCrossing;

    private void Start()
    {
        _pedestrianCrossing = GetComponentInChildren<PedestrianCrossing>();
        
        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
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