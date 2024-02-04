using UnityEngine;

public class EnemyAssignmentComponent : MonoBehaviour
{
    private GameObject[] enemies;

    private void Start()
    {
        OverlayEnemyTarget();
    }

    /// <summary>
    /// Всем объектам с тэгом "Enemy" назначается компонент EnemyTargetMouse
    /// </summary>
    private void OverlayEnemyTarget()
    {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.AddComponent<EnemyTargetMouse>();
                enemy.AddComponent<EnemyAI>();
            }
        }
    }
}
