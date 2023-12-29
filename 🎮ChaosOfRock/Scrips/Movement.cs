using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed, jumpForce, speedBack, movementHorizontal;
    public GameObject bulletPoint;
    public float maxDistance;
    private HealthBar _healthBar;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] public bool isGrounded, notMove;

    private void Start()
    {
        notMove = true;
        _healthBar = FindObjectOfType<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CheckFixedUpdate();
    }

    private void Update()
    {
        CheckUpdate();
    }

    /// <summary>
    /// Проверка на выполнение FixedUpdate
    /// </summary>
    private void CheckFixedUpdate()
    {
        if (_healthBar.isAlive == true && notMove == true)
        {
            GroundedCheck();
            MoveLogic();
        }
    }

    /// <summary>
    /// Проверка на выполнение Update
    /// </summary>
    private void CheckUpdate()
    {
        if (_healthBar.isAlive && notMove && !FindObjectOfType<GameManager>().PauseBlock) JumpLogic();
    }

    /// <summary>
    /// Логика движения персонажа
    /// </summary>
    void MoveLogic()
    {
        // Движение вперед/назад 
        transform.position += new Vector3(speedBack, 0, 0) * speed * Time.deltaTime;
        movementHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementHorizontal, 0, 0) * speed * Time.deltaTime;

        // Движение назад (не поворачиваясь)
        if (Input.GetKey(KeyCode.LeftControl))
        {
            movementHorizontal = 0;
            if (transform.localScale.x <= -1) speedBack = 1;
            if (transform.localScale.x >= 1) speedBack = -1;
        }

        else speedBack = 0;

        // Повороты при движение
        if (movementHorizontal > 0) SetPlayerOrientation(1, Quaternion.Euler(0, 0, 0));
        else if (movementHorizontal < 0) SetPlayerOrientation(-1, Quaternion.Euler(0, 180, 0));

    }

    /// <summary>
    /// Логика прыжка 
    /// </summary>
    void JumpLogic()
    {
        // Прыжок
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce * 100, ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
        }
    }

    /// <summary>
    /// Проверка нахождение на земле
    /// </summary>
    void GroundedCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, maxDistance, groundMask);
    }

    /// <summary>
    /// Установка ориентации игрока и пули
    /// </summary>
    void SetPlayerOrientation(float scaleX, Quaternion bulletRotation)
    {
        transform.localScale = new Vector3(scaleX, 1, 1);
        bulletPoint.transform.localRotation = bulletRotation;
    }
}
