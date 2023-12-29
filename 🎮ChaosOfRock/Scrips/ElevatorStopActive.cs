using UnityEngine;

public class ElevatorStopActive : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Elevator>()) FindObjectOfType<Elevator>().GetComponent<AudioSource>().Stop();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Elevator>()) FindObjectOfType<Elevator>().GetComponent<AudioSource>().Play();
    }
}
