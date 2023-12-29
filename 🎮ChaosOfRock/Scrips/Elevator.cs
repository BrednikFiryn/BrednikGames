using UnityEngine;

public class Elevator : MonoBehaviour
{
    private SliderJoint2D _slide;

    public bool Down;
    public float SpeedMotor;
    public GameObject CrystalActive;
    public GameObject CrystalInActive;
    public Transform ElevatorPoint;
    [SerializeField] private GameManager Manager;


    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        _slide = GetComponent<SliderJoint2D>();
        Down = false;
        _slide.connectedAnchor = ElevatorPoint.position;
    }

    private void FixedUpdate()
    {
        platformController();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            Manager.E.SetActive(true);
            CheckPressed();
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
    /// Движение лифта
    /// </summary>
    private void platformController()
    {
        JointMotor2D motor = _slide.motor;

        if (Down == true)
        {
            motor.motorSpeed = SpeedMotor;
            _slide.motor = motor;
        }

        if (Down == false)
        {
            motor.motorSpeed = -SpeedMotor;
            _slide.motor = motor;
        }
    }

    /// <summary>
    /// Проверка нажатия
    /// </summary>
    private void CheckPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Manager.SoulCrystal == true)
            {
                if (Down == false)
                {
                    CrystalActive.SetActive(true);
                    CrystalInActive.SetActive(false);
                    Down = true;
                }

                else if (Down == true)
                {
                    CrystalActive.SetActive(false);
                    CrystalInActive.SetActive(true);
                    Down = false;
                }
            }

            else
            {
                FindObjectOfType<GameManager>().PauseMonolog();
                Manager.NotificationAlert();
            }
        }
    }
}
