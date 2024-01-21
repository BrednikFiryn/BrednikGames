using UnityEngine;
using System.Collections.Generic;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] public float speed, Damage;

    [SerializeField] float TimeToDestroyStart;
    private float TimeToDestroy;
    [SerializeField] private LayerMask GroundMask;

    public List<GameObject> objects;

    private ClassController _classController;

    private void Awake()
    {
        _classController = FindObjectOfType<ClassController>();
        TimeToDestroy = TimeToDestroyStart;
    }

    private void FixedUpdate()
    {
        BulletLogic();
    }

    /// <summary>
    /// �������� ���� 
    /// </summary>
    void BulletLogic()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        PlasmaDestroy();
    }

    /// <summary>
    /// ����������� ����, ����� time 
    /// </summary>
    void PlasmaDestroy()
    {
        if (TimeToDestroy <= 0)
        {
            DestroyBullet();
            Destroy(gameObject, 1f);
        }

        TimeToDestroy -= Time.deltaTime;
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    void PlasmaCollision()
    {
        DestroyBullet();
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // ���������� ���� ��� ������� � "Object"
        if (collision.tag == "Object")
        {
            PlasmaCollision();
        }

        // ���������� ���� ��� ������� � "Gate"
        if (collision.name == "Gate")
        {
            PlasmaCollision();
        }

        // ���������� ���� ��� ������� � "Enemy"  
         if (collision.CompareTag("Golem"))
         {
            collision.GetComponent<InterfaceEnemy>().TakeDamage(Damage);
            Debug.Log("1");
            Destroy(GetComponent<Collider2D>());
            PlasmaCollision();
         }

        // ���������� ���� ��� ������� � "Bullet"  
        if (collision.CompareTag("Bullet"))
        {
            PlasmaCollision();
            Destroy(GetComponent<Collider2D>());
        }
    }

    /// <summary>
    /// ����������� ����
    /// </summary>
    private void DestroyBullet()
    {
        speed = 0;

        foreach (var obj in objects)
        {
            objects[0].SetActive(false);
            objects[1].SetActive(true);
        }
    }
}
