using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
   [SerializeField] private float moveSpeed = 10f;
   [SerializeField] private float moveRun = 10f;
   [SerializeField] private float rotateSpeed = 75f;

    [HideInInspector] public float moveSpeedStart;
    [HideInInspector] public float moveSpeedSlow;

    private Rigidbody _rb;

    private PlayerInput playerInput;
    private BarrierCollision barrierCollision;


    private void Start()
    {
        moveSpeedSlow = moveSpeed / 2;
        moveSpeedStart = moveSpeed;
        _rb = GetComponent<Rigidbody>();
        barrierCollision = FindObjectOfType<BarrierCollision>();
        playerInput = FindObjectOfType<PlayerInput>();
}

    private void FixedUpdate()
    {
        MoveLogic();
    }

    private void Update()
    {
        CheckSpeed();
    }

    private void MoveLogic()
    {
        Vector3 rotation = Vector3.up * playerInput.hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * rotateSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * playerInput.vInput * moveSpeed * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    private void CheckSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !barrierCollision.stop)
        {
            moveSpeed = moveRun;
        }

        else if (barrierCollision.stop)
        {
            moveSpeed = moveSpeedSlow;
        }

        else
            moveSpeed = moveSpeedStart;

    }
}
