using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    private Rigidbody _rb;

    private PlayerBehavior _playerBehavior;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerBehavior = GetComponent<PlayerBehavior>();
    }
    void FixedUpdate()
    {
        PlayerMoveRigidbody();
    }

    private void PlayerMoveRigidbody()
    {
        Vector3 rotation = Vector3.up * _playerBehavior.hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * rotateSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * _playerBehavior.vInput * moveSpeed * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        //this.transform.Translate(Vector3.right * hInput * Time.deltaTime);
    }
}
