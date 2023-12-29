using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    private float angleHorizontal;
    public float sensitivityMouse = 5f;
    private Quaternion originalRotation;
    public Transform player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        RotationBody();
    }

    /// <summary>
    /// �������� ���� ��� ������ ����
    /// </summary>
    void RotationBody()
    {
        angleHorizontal += Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;

        // ������������ ���� �������
        angleHorizontal = Mathf.Clamp(angleHorizontal, -10f, 20f);

        // ��������� �������� � ����������� �� ����������� ������
        Vector3 rotationAxis = (player.localScale.x >= 1) ? Vector3.forward : Vector3.back;
        Quaternion rotation = Quaternion.AngleAxis(angleHorizontal, rotationAxis * Time.deltaTime);

        // ��������� �������� � ����
        transform.rotation = originalRotation * rotation;
    }
}