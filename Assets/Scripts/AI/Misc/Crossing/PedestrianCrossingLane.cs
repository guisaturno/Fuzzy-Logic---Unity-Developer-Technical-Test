using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PedestrianCrossingLane : MonoBehaviour
{
    //Private variables
    private PedestrianCrossing _pedestrianCrossing;

    //MonoBehaviour callbacks
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
                other.GetComponentInParent<AIBrain>().IsWaiting = true;
            else
                other.GetComponentInParent<AIBrain>().IsWaiting = false;
            
            other.GetComponentInParent<CarBrain>().AtCrossing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vehicle"))
            other.GetComponentInParent<CarBrain>().AtCrossing = false;
    }
}