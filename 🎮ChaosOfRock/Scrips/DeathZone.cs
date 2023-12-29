using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public float damage;
    public GameObject playerDeath;
    [SerializeField] private Animator Anim;
    public HealthBar health;
    public GameManager gameManager;


    private void Start()
    {
        health = FindObjectOfType<HealthBar>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {

            if (gameObject.name == "Water")
            {
                DeathActive();
                Anim.SetBool("Water", true);
            }

            if (gameObject.name == "Trap")
            {
                DeathActive();
                Anim.SetBool("TrapLeft", true);
            }

            if (gameObject.name == "ElevatorNotActive" && FindObjectOfType<Elevator>().Down == false)
            {
                GetComponent<AudioSource>().Play();
                gameManager.PlayerObjectsOff();
                gameManager.DeathPlayer();
                playerDeath.SetActive(true);

                Anim.SetBool("ElevatorNotActive", true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("HitBox") && gameObject.name == "Fire")
        {
            gameManager.DeathFireActive();
        }
    }

    /// <summary>
    /// Событие: смерть
    /// </summary>
    private void DeathActive()
    {
        gameManager.PlayerObjectsOff();
        health.health = 0;
        playerDeath.SetActive(true);
    }
}
