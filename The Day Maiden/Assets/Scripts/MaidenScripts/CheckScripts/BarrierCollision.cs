using UnityEngine;

public class BarrierCollision : MonoBehaviour
{

    [HideInInspector] public bool stop; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            stop = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            stop = false;
        }
    }
}
