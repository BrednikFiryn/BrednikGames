using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutChain : MonoBehaviour
{
    public GameObject Point;
    public GameObject Player;
    [SerializeField] private GameManager Button;

    private void Start()
    {
        Button = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            Button.E.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.transform.position = Point.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            Button.E.SetActive(false);
        }
    }
}
