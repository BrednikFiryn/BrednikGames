using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] public bool isGrounded;
    [SerializeField] private LayerMask GroundMask;

    public InterfaceEnemy InterfaceEnemy;

    public float MaxDistance;

    void Update()
    {
        GorundedCheck();
    }

    /// <summary>
    ///проверка нахождение на земле
    /// </summary>
    void GorundedCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, MaxDistance, GroundMask);

        if (!isGrounded) InterfaceEnemy.agr = false;
        else return;

    }
}
