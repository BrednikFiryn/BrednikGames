using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] private float rotateSpeed = 75f;
   [SerializeField] public float move = 10f;
   [SerializeField] public float moveSpeed = 10f;

    private Rigidbody _rb;
    private PlayerInput playerInput;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        playerInput = FindObjectOfType<PlayerInput>();
    }

    private void FixedUpdate()
    {
        MoveLogic();
    }

    /// <summary>
    /// Движение и поворот.
    /// </summary>
    private void MoveLogic()
    {
        Vector3 rotation = Vector3.up * playerInput.hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * rotateSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * playerInput.vInput * move * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
