using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    [HideInInspector] public bool isGrounded;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask groundMask;

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxDistance, groundMask);
    }
}
