using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class TJunction : MonoBehaviour
{
    //Private variables
    private bool isSafeRight;
    private bool isSafeLeft;

    //Properties
    public bool IsSafeRight
    {
        set => isSafeRight = value;
    }

    //Properties
    public bool IsSafeLeft
    {
        set => isSafeLeft = value;
    }

    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            AIBrain otherBrain = other.GetComponent<AIBrain>();

            if (otherBrain.CurrentPath[otherBrain.CurrentPathPoint].position.x < gameObject.transform.position.x)
            {
                if (isSafeRight)
                    otherBrain.IsWaiting = false;
                else
                    otherBrain.IsWaiting = true;
            }
            else if (isSafeLeft)
                otherBrain.IsWaiting = false;
            else
                otherBrain.IsWaiting = true;
        }
    }
}