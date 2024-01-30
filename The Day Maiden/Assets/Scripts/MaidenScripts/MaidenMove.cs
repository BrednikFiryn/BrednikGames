using UnityEngine;

public class MaidenMove : MonoBehaviour
{
    
    public float moveSpeed = 10f;
    public float moveRun = 10f;
    public float rotateSpeed = 75f;
    public GameObject MAtter;
    public GameObject Spirit;

    private float moveSpeedStart;
    private Rigidbody _rb;
    private PlayerBehavior playerBehavior;

    private void Start()
    {
        moveSpeedStart = moveSpeed;
        _rb = GetComponent<Rigidbody>();
        playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    void FixedUpdate()
    {
        MoveRotation();
    }

    private void Update()
    {
        CheckSpeed();
    }

    private void MoveRotation()
    {
        Vector3 rotation = Vector3.up * playerBehavior.hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * rotateSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * playerBehavior.vInput * moveSpeed * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    private void CheckSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = moveRun;
            MAtter.SetActive(false);
            Spirit.SetActive(true);
        }

        else
        {
            moveSpeed = moveSpeedStart;
            MAtter.SetActive(true);
            Spirit.SetActive(false);
        }
    }
}
