using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class IntersectionStop : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private int myTurnNumber;

    //Private variables
    private Intersection _intersection;

    private void Start()
    {
        _intersection = GetComponentInParent<Intersection>();

        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            if (_intersection.CurrentTurn == myTurnNumber)
                other.GetComponent<AIBrain>().IsWaiting = false;
            else
                other.GetComponent<AIBrain>().IsWaiting = true;
        }
    }
}