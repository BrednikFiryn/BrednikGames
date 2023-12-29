using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float AttackDistance, TimeAttackMax;
    private float TimeToAttack;

    ClassController _classController;

    Transform player;
    [SerializeField] GameObject BulletEnemy;
    public Transform shootPointEnemy;
    public Animator anim;

    public bool RightAttack;


    void Start()
    {
        _classController = FindObjectOfType<ClassController>();

        TimeToAttack = TimeAttackMax;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        CheckEnemyLife();
    }

    /// <summary>
    /// Логика атаки противника
    /// </summary>
    private void AttackLogicEnemy()
    {
        if (player.position.x < transform.position.x) { RightAttack = false; }

        else if (player.position.x > transform.position.x) { RightAttack = true; }

        if (RightAttack == false)
        {
            AttackLeft();
            shootPointEnemy.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        else if (RightAttack == true)
        {
            AttackRight();
            shootPointEnemy.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    /// <summary>
    /// Атака на лево 
    /// </summary>
    private void AttackLeft()
    {
        if (player.position.x > transform.position.x - AttackDistance)
        {
            GetComponent<PatrollEnemy>().speed = 0;

            if (TimeToAttack <= 0) { AttackTime(); }

            else { TimeToAttack -= Time.deltaTime; }
        }

        else { GetComponent<PatrollEnemy>().speed = GetComponent<PatrollEnemy>().StartSpeed; }
    }

    /// <summary>
    /// Атака на право
    /// </summary>
    private void AttackRight()
    {
        if (player.position.x < transform.position.x + AttackDistance)
        {
            GetComponent<PatrollEnemy>().speed = 0;

            if (TimeToAttack <= 0)
            {
                AttackTime();
            }
            else TimeToAttack -= Time.deltaTime;
        }

        else GetComponent<PatrollEnemy>().speed = GetComponent<PatrollEnemy>().StartSpeed;
    }

    /// <summary>
    /// Атака спустя time
    /// </summary>
    private void AttackTime()
    {
        Instantiate(BulletEnemy, shootPointEnemy.position, shootPointEnemy.rotation);
        anim.SetTrigger("Attack");
        TimeToAttack = TimeAttackMax;
    }

    /// <summary>
    /// Проверка остатка жизни 
    /// </summary>
    private void CheckEnemyLife()
    {
        if (GetComponent<InterfaceEnemy>().isLifeEnemy && _classController._HealthBar.isAlive) { AttackLogicEnemy(); }
    }
}
