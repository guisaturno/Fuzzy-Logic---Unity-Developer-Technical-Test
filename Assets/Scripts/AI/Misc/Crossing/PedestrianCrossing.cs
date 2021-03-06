using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PedestrianCrossing : MonoBehaviour
{
    //Private variables
    private bool isCrossing;
    
    //Properties
    public bool IsCrossing => isCrossing;

    //MonoBehaviour callbacks
    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

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