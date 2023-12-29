using System.Collections.Generic;
using UnityEngine;

public class EnemyBoom : MonoBehaviour
{
    private HealthBar healthBar;
    private SoundController soundController;
    public Rigidbody2D Player;
    public List<GameObject> EnemyStates;
    public AudioSource boom;

    public float Damage, thrust;

    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    /// <summary>
    ///  Нанесение урона игроку
    /// </summary>
    /// <param name="Damage"></param>
    /// <returns></returns>
    public float PlayerDamage(float Damage)
    {
        return healthBar.health -= Damage;
    }

    /// <summary>
    /// Направление толчка
    /// </summary>
    private void CheckThrust()
    {
        if (GetComponent<PatrollEnemy>().ThrustRight) { Player.AddForce(transform.right * thrust, ForceMode2D.Impulse); }

        else if (!GetComponent<PatrollEnemy>().ThrustRight) { Player.AddForce(transform.right * -thrust, ForceMode2D.Impulse); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            foreach (var state in EnemyStates)
            {
                EnemyStates[0].SetActive(false);
                EnemyStates[1].SetActive(true);
            }

            soundController.Sounds.Remove(boom);
            GetComponent<DeathEnemyController>().SoundDeathRemove();
            CheckThrust();
            PlayerDamage(Damage);
            GetComponent<PatrollEnemy>().speed = 0f;
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 1f);
        }
    }

    /// <summary>
    /// Удаление звука взрыва из коллекции 
    /// </summary>
    public void SoundBoomRemove()
    {
        soundController.Sounds.Remove(boom);
    }
}
