using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLook : MonoBehaviour
{
    GameObject player;
    public float stoppingDistance;
    Quaternion OriginalRotation;

    void Start()
    {
        OriginalRotation = transform.rotation;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        RotationEnemy();
    }

    /// <summary>
    /// Враг смотрит в сторону игрока 
    /// </summary>
    public void RotationEnemy()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance)
        {
            Vector3 Look = transform.InverseTransformPoint(player.transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 180;

            transform.Rotate(0, 0, Angle);
        }
        else transform.rotation = OriginalRotation;
    }


}
