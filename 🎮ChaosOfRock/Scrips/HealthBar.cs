using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public bool isAlive = true;
    [SerializeField] public float health;
    [SerializeField] private Animator anim;
    [SerializeField] public GameObject deathDoll;
    [SerializeField] private FireTick fireTick;

    private void Start()
    {
        isAlive = true;
    }

    private void Update()
    {
        HealthCount();
    }

    /// <summary>
    /// Health counter
    /// </summary>
    private void HealthCount()
    {
        health = Mathf.Clamp01(health); // Ensure health stays between 0 and 1

        if (health <= 0)
        {
            health = 0;
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        FindObjectOfType<SoundController>()?.AllAudioPause();
        FindObjectOfType<GameManager>()?.PlayerObjectsOff();
        deathDoll.SetActive(true);
        isAlive = false;

        anim.SetBool(fireTick.isFire ? "DeathFire" : "Death", true);
    }

    /// <summary>
    /// Healing
    /// </summary>
    /// <param name="hp"></param>
    public void HpCount(float hp)
    {
        health += hp;
    }

    /// <summary>
    /// Taking damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
