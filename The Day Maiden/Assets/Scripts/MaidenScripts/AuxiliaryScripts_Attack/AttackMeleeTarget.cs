using UnityEngine;

public class AttackMeleeTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyTargetMouse>())
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyTargetMouse>())
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
