using UnityEngine;

public class AltarTakeDamage : MonoBehaviour
{
    [SerializeField] private float altarHealth;
    [SerializeField] private float EnemyDamage;
    [SerializeField] private GameObject altarDeath;
    [SerializeField] private GameObject altarLife;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            altarHealth -= EnemyDamage;

            if (altarHealth == 0)
            {
                altarLife.SetActive(false);
                altarDeath.SetActive(true);
            }
        }
    }
}
