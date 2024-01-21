using System.Collections.Generic;
using UnityEngine;

public class PedestalDarkness : MonoBehaviour
{
    public List<GameObject> Monolog;
    public InterfaceController _InterfaceController;
    [SerializeField] private Movement Move;
    public GameManager gameManager;
    public AudioSource FinalSound;
    public Animator anim;

    private void Start()
    {
         gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            gameManager.E.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Move = FindObjectOfType<Movement>();

                if (!_InterfaceController.EnemyNull) Monolog[0].SetActive(true); 

                else if (gameManager.FilthCrystal && gameManager.SoulCrystal && gameManager.RedCrystal)
                {
                    Monolog[2].SetActive(true);
                    Move.notMove = false;
                    gameManager.PlayerObjectsOff();
                    anim.SetBool("Active", true);
                    Destroy(GetComponent<Collider2D>());
                }

                else Monolog[1].SetActive(true); 

                FinalSound.Pause();
                gameManager.PauseMonolog();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Legs")) gameManager.E.SetActive(false);
    }
}