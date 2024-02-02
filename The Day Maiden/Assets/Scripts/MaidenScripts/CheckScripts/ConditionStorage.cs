using UnityEngine;

public class ConditionStorage : MonoBehaviour
{
    public GameObject matter;
    public GameObject spirit;

    private BarrierCollision barrierCollision;
    private GroundCheck groundCheck;


    private void Start()
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
