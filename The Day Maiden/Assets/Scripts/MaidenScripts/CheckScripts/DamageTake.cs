using UnityEngine;

public class DamageTake : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyTarget>())
        {
            Destroy(other.gameObject, 0.5f);
        }
    }
}
