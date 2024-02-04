using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;

    [HideInInspector]public GameObject enemyTarget;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyTarget = GameObject.FindGameObjectWithTag("EnemyTarget");
    }

    void Start()
    {
        TargetOfEnemyAttack();
    }

    /// <summary>
    /// Перемещение врага в точку.
    /// </summary>
    public void TargetOfEnemyAttack()
    {

        agent.speed += 5;

        if (agent != null && enemyTarget != null)
        {
            agent.SetDestination(enemyTarget.transform.position);
        }
    }
}
