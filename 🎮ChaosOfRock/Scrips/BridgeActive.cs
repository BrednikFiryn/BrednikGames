using UnityEngine;

public class BridgeActive : MonoBehaviour
{
    public Animator Bridge;
    public GameObject CrystalActive, CrystalInactive, BridgeActiveText;

    private GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            manager.E.SetActive(true);
            CheckPressed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            manager.E.SetActive(false);
        }
    }

    /// <summary>
    /// Check if the button is pressed
    /// </summary>
    private void CheckPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (manager.RedCrystal)
            {
                ActivateBridge();
            }
            else
            {
                BridgeActiveText.SetActive(true);
                manager.PauseMonolog();
            }
        }
    }

    private void ActivateBridge()
    {
        Bridge.SetBool("Active", true);
        CrystalActive.SetActive(true);
        Destroy(GetComponent<Collider2D>());
    }
}