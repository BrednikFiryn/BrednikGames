using UnityEngine;

public class ConditionStorage : MonoBehaviour
{
    private BarrierCollision barrierCollision;
    private GroundCheck groundCheck;

    public GameObject matter;
    public GameObject spirit;


    private void Awake()
    {
        barrierCollision = FindObjectOfType<BarrierCollision>();
        groundCheck = FindObjectOfType<GroundCheck>();
    }

    private void Update()
    {
        ConditionCheck();
    }

    private void ConditionCheck()
    {
        if (!groundCheck.isGrounded || Input.GetKey(KeyCode.LeftShift) && !barrierCollision.stop)
        {
            matter.SetActive(false);
            spirit.SetActive(true);
        }

        else
        {
            matter.SetActive(true);
            spirit.SetActive(false);
        }
    }
}
