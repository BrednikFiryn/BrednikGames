using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator anim;
    public bool Open;
    [SerializeField] private GameManager Manager;


    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        Open = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            Manager.E.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && Open == false)
            {
                if (gameObject.name == "Gate(Soul)" && Manager.SoulCrystal == true)
                {
                    OpenGateAndDestroy();
                }

                else if (gameObject.name == "Gate(Filth)" && Manager.FilthCrystal == true)
                {
                    OpenGateAndDestroy();
                }

                else
                {
                    FindObjectOfType<GameManager>().PlayerObjectsOff();
                    Manager.PauseBlock = true;
                    Manager.NotificationAlert();
                }
            }    
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            Manager.E.SetActive(false);
        }
    }

    /// <summary>
    /// Открытие ворот и уничтожение колайдера.
    /// </summary>
    private void OpenGateAndDestroy()
    {
        anim.SetBool("Gate", true);
        Open = true;
        Destroy(GetComponent<Collider2D>());
    }
}
