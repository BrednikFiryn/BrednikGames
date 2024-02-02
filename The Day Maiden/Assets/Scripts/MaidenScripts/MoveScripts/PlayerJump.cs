using UnityEngine;

public class PlayerJump : MonoBehaviour
{
     [SerializeField] private float jumpVelocity = 5f;

    private Rigidbody _rb;

    private GroundCheck groundCheck;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        groundCheck = FindAnyObjectByType<GroundCheck>();
    }

    private void FixedUpdate()
    {
        JumpLogic();
    }

    private void JumpLogic()
    {
        if (Input.GetKey(KeyCode.Space) && groundCheck.isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpVelocity * 100, ForceMode.Impulse);
        }
    }
}
