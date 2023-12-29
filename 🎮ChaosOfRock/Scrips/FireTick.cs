using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class FireTick : MonoBehaviour
{
    public float fireTimeRoutine, fireTimeMax, fireTime, damage;
    public bool isFire;

    public Image fireImage;
    public HealthBar healthBar;
    public GameObject playerDeath;
    public AudioSource fireDamage;
    public AudioSource fireMonolog;

    private GameManager gameManager;

    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        gameManager = FindObjectOfType<GameManager>();
        fireTime = 0;
        fireImage.fillAmount = 1f;
    }

    private void Update()
    {
        TimeFire();
        DeathFire();
    }

    /// <summary>
    /// Время горения 
    /// </summary>
    private  void TimeFire()
    {
        fireTime -= Time.deltaTime;
        fireImage.fillAmount = fireTime / fireTimeMax;

        if (fireTime > 0 && !gameManager.PauseBlock)
        {
            isFire = true;
            StartCoroutine(FireTickRoutine());
        }

         else if (fireTime <= 0)
        {
            isFire = false;
            fireTime = 0;
            fireMonolog.Play();
            fireDamage.Stop();
        }
    }

    private IEnumerator FireTickRoutine()
    {
        yield return new WaitForSeconds(fireTimeRoutine);
        TakeDamage(damage);
    }


    /// <summary>
    /// Смерть от горения
    /// </summary>
    private void DeathFire()
    {
        if (healthBar.health <= 0)
        {
            playerDeath.SetActive(true);
            healthBar.health = 0;
            gameManager.PlayerObjectsOff();
        }
    }

    /// <summary>
    /// Нанесение урона
    /// </summary>
    /// <param name="Damage"></param>
    /// <returns></returns>
    public float TakeDamage(float Damage)
    {
        return healthBar.health -= Damage * Time.deltaTime;
    }
}
