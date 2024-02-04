using UnityEngine;

public class DamageTake : MonoBehaviour
{
    private AttackDistantTarget attackDistantTarget;

    private void Start()
    {
        attackDistantTarget = FindObjectOfType<AttackDistantTarget>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            attackDistantTarget.target = null;
            other.gameObject.SetActive(false);
        }
    }
}