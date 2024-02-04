using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnPoint : MonoBehaviour
{
    private GameObject[] spawnPoints;
    [HideInInspector] public GameObject[] enemies;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    private void Start()
    {
        EnemyAssignPoint();
    }

    /// <summary>
    /// Спавн врагов на точках.
    /// </summary>
    public void EnemyAssignPoint()
    {
        int enemyCount = enemies.Length;
        int spawnPointCount = spawnPoints.Length;

        for (int i = 0; i < enemyCount; i++)
        {
            int spawnindex = i % spawnPointCount;
            Transform spawnPointTransform = spawnPoints[spawnindex].transform;

            enemies[i].transform.position = spawnPointTransform.position;

            if (enemies[i].TryGetComponent(out NavMeshAgent navMeshAgent))
            {
                navMeshAgent.Warp(spawnPointTransform.position);
            }
        }
    }
}
