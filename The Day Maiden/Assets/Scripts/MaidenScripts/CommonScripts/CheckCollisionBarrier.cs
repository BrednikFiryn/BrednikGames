using UnityEngine;

public class CheckCollisionBarrier : MonoBehaviour
{
    [SerializeField] private float moveFastSpeed = 10f;

    private BarrierCollision barrierCollision;
    private PlayerMove playerMove;
    private float moveSpeedSlow;


    void Awake()
    {
        barrierCollision = FindObjectOfType<BarrierCollision>();
        playerMove = FindObjectOfType<PlayerMove>();
    }

    private void Start()
    {
        moveSpeedSlow = playerMove.move / 2;
    }

    void Update()
    {
        CheckSpeed();
    }

    /// <summary>
    /// Изменение скорости при стольковении с баръером уровня.
    /// </summary>
    private void CheckSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !barrierCollision.stop)
        {
            playerMove.move = moveFastSpeed;
        }

        else if (barrierCollision.stop)
        {
            playerMove.move = moveSpeedSlow;
        }

        else
            playerMove.move = playerMove.moveSpeed;
    }
}
