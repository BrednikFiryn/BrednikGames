using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] public float speed, Damage;

    public List<GameObject> objects;

    private ClassController _classController;
    private Transform player;

    private void Awake()
    {
        _classController = FindObjectOfType<ClassController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        BulletLogic();
    }

    /// <summary>
    /// Движение пули 
    /// </summary>
    void BulletLogic()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    /// <summary>
    /// Колизия пули
    /// </summary>
    void PlasmaCollision()
    {
        DestroyBullet();
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Разрушение пули при колизии с "Object"
        if (collision.tag == "Object") PlasmaCollision();

        // Разрушение пули при колизии с "Gate"
        if (collision.name == "Gate(Filth)" || collision.name == "Gate(Soul)") PlasmaCollision();

        // Разрушение пули при колизии с "HitBox"  
        if (collision.tag == "HitBox")
        {
            _classController._HealthBar.TakeDamage(Damage);
            PlasmaCollision();
        }

        // Разрушение пули при колизии с "Bullet"  
        if (collision.CompareTag("Bullet"))
        {
            PlasmaCollision();
            Destroy(GetComponent<Collider2D>());
        }
    }

    /// <summary>
    /// Разурушение пули
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
