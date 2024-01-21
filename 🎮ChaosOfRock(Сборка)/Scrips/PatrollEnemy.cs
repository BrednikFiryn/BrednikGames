
using UnityEngine;

public class PatrollEnemy : MonoBehaviour
{

    // скорость и дистанция патрулирования
    [SerializeField] public float speed, positionOfPotrol, stoppingDistance;
    public float StartSpeed;

    // позиция
    [SerializeField] public Transform point;
    private Transform player;
    private ClassController _ClassController;
    public GroundCheck _GroundCheck;

    // Проверка
    public  bool ThrustRight;
    private bool chill, angry, goBack = false, MoveingRight;

    private void Start()
    {
        gameObject.transform.position = point.transform.position;
        StartSpeed = speed;
        _ClassController = FindObjectOfType<ClassController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        CheckLifeEnemy();
    }

    /// <summary>
    /// Логика движения противника 
    /// </summary>
    private void MoveLogicEnemy()
    {

        if (Vector2.Distance(transform.position, point.position) < positionOfPotrol && angry == false) chill = true;

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance || GetComponent<InterfaceEnemy>().agr && _ClassController._HealthBar.isAlive)
        {
            LookAtPlayer();
            angry = true;
            goBack = false;
            chill = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && !GetComponent<InterfaceEnemy>().agr || !_ClassController._HealthBar.isAlive 
            || !_GroundCheck.isGrounded)
        {
            goBack = true;
            angry = false;
        }

        if (chill) Chill();

        else if (angry) Angry();

        else if (goBack) GoBack();
    }

    /// <summary>
    /// Состояние покоя. Патрулирование заданной зоны 
    /// </summary>
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPotrol)
        {
            MoveingRight = false;
        }

        else if (transform.position.x < point.position.x - positionOfPotrol)
        {
            MoveingRight = true;
        }

        if (MoveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(-1, 1);
        }          

        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(1, 1);
        }
          
    }

    /// <summary>
    /// Состояние при котором игрок приближается на определенное расстояние 
    /// </summary>
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    /// <summary>
    /// Возвращение в зону патрлирования, в случае отдаления игрока на определенное расстояние 
    /// </summary>
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

    /// <summary>
    /// Враг смотрит в сторону игрока
    /// </summary>
    void LookAtPlayer()
    {
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            ThrustRight = true;
        }

        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
            ThrustRight = false;
        }
    }

    /// <summary>
    /// Проверка остатка жизни 
    /// </summary>
    void CheckLifeEnemy()
    {
        if (GetComponent<InterfaceEnemy>().isLifeEnemy) MoveLogicEnemy();
    }   
    
}
